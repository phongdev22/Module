using Microsoft.AspNetCore.Mvc;
using Module.Entities;
using Module.Models;
using Microsoft.EntityFrameworkCore;
using Module.Utils;
using System.Text.RegularExpressions;
using NuGet.Protocol;
using Microsoft.CodeAnalysis.Scripting;

namespace Module.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        public MyDbContext _db;
        public IConfiguration _config;
        public EventController(IConfiguration config, MyDbContext db)
        {
            _db = db;
            _config = config;
        }

        [HttpGet("config")]
        public IActionResult Config()
        {
            return Ok(new
            {
                Code = 0
            });
        }

        [HttpPost]
        public async Task<IActionResult> Index([FromBody] CallResponse eventCall)
        {
            var status = eventCall.call_status;
            var idenCode = eventCall.request_from_user_id.Split("_")[0];

            switch (status)
            {
                case "started":
                    _db.Calls.Add(new Call()
                    {
                        CallId = eventCall.call_id,
                        From = eventCall.from.number,
                        To = eventCall.to.number,
                        AccountSid = eventCall.account_sid,
                        TimeStart = eventCall.timestamp_ms
                    });

                    break;
                case "ended":
                    _db.CallDetails.Add(new CallDetail()
                    {
                        CallId = eventCall.call_id,
                        Duration = eventCall.duration,
                        AnswerDuration = eventCall.answerDuration,
                        EndedBy = eventCall.endedBy,
                        EndedCause = eventCall.endCallCause,
                        Status = eventCall.call_status.ToString(),
                        TimeEnd = eventCall.timestamp_ms,
                    });

                    var receiverNumber = eventCall.to.number;
                    var eventCause = eventCall.endCallCause;
                    var account = await _db.Accounts.FirstOrDefaultAsync(acc => acc.IdentityCode == idenCode);
                    
                    var configuration = _db.EventConfigurations.FirstOrDefault(ev => ev.IdentityCode == idenCode && eventCause == ev.EventName);

                    if (account == null)
                        throw new Exception("Cannot find account to send");

                    if (configuration == null)
                        throw new Exception("Configuration is not defined");

                    //if (!IsPhoneNumber(receiverNumber))
                    //    throw new Exception("Phone number is wrong format");

                    var sender = new RequestSender();

                    Dictionary<string, dynamic> body = new Dictionary<string, dynamic>();

					var lst_params = configuration.ListParams.Split(",");
					var flatten = Converter.ConvertToDictionary(eventCall);

                    // get params from
					foreach (var pr in lst_params)
					{
						var find_str = @$"[{pr.Trim()}]";
						if (flatten.ContainsKey(pr))
						{
							string value = flatten[pr];
							body.Add(pr,value);
						}
					}

					/*
                     * string script = configuration.Script;

                    if (configuration.ListParams == "") body.Add("script", script);
                    else
                    {
                        var lst_params = configuration.ListParams.Split(",");

						// Data object will be flatten. Enhanced (callAPI to get data, after that flattern and filtering field respectively) 
						// 
                        var flatten = Converter.ConvertToDictionary(eventCall);

                        foreach (var pr in lst_params)
                        {
                            var find_str = @$"[{pr.Trim()}]";
                            if (flatten.ContainsKey(pr))
                            {
                                string value = flatten[pr];
                                script = script.Replace(find_str, value);
                            }
                        }

                        body.Add("script", script);
                    }
                    */

					// call API 
					var dataOmni = new
                    {
                        username = account.Username,
                        password = account.Password,
                        phonenumber = receiverNumber,
                        routerule = configuration.RouteRule.Split(","),
                        templatecode = configuration.TemplateCode,
                        list_param = body
                    };
                    
                    var messageLog = new ActivityHistory()
                    {
                        CallId = eventCall.call_id,
                        Recipient = eventCall.to.alias,
                        Status = "",
                        StatusMessage = "",
                    };

                    var resp = await sender.SendRequestAsync(_config["INCOM_TEST_ENV:url"], HttpMethod.Post, dataOmni.ToJson()) ?? "{}";

                    dynamic responseObject = Newtonsoft.Json.JsonConvert.DeserializeObject(resp);

                    string response_status = responseObject?.status ?? "";
                    string response_code = responseObject?.code ?? "";

                    messageLog.Status = response_status;
					messageLog.StatusMessage = response_code;

					//if (response_status == "1")
					//    messageLog.StatusMessage = script;
					//else messageLog.StatusMessage = response_code;

					// Save data
					_db.ActivityHistory.Add(messageLog);
                    break;
                default:
                    break;
            }

            await _db.SaveChangesAsync();
            return Ok();
        }

        private bool IsPhoneNumber(string number)
        {
            Regex regex = new Regex(@"^84\d{9}$");
            if (regex.IsMatch(number))
                return true;
            return false;
        }

    }
}