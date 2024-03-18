using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Module.Entities;
using System.Runtime.InteropServices;

namespace Module.Controllers
{
	public class HomeController : Controller
	{
		private readonly MyDbContext _context;
		public HomeController(MyDbContext context)
		{
			_context = context;
		}

		[HttpGet]
		public IActionResult Index()
		{
			var result = _context.Database
				.SqlQueryRaw<dynamic>(@"SELECT *
				FROM Calls
				JOIN CallDetail ON Calls.CallId = CallDetail.CallId
				JOIN ActivationHistory ON Calls.CallId = ActivationHistory.CallId;
			");

			return View();
			//return Ok(result);
		}

		[HttpPost]
		public async Task<IActionResult> Index(
			[FromForm] string IdentityCode,
			[FromForm] string EventName,
			[FromForm] string TemplateCode,
			[FromForm] string RouteRule,
			[FromForm] string DefaultValue,
			[FromForm] string ListParams)
		{

			var account = _context.Accounts.FirstOrDefault(acc => IdentityCode.Equals(acc.IdentityCode));

			if (account == null)
			{
				TempData["Message"] = "Please create your identity code";
				return RedirectToAction("CreateAccount");
			}

			_context.EventConfigurations.Add(new EventConfiguration()
			{
				IdentityCode = IdentityCode.Trim(),
				EventName = EventName.Trim(),
				TemplateCode = TemplateCode.Trim(),
				RouteRule = RouteRule.Trim(),
				DefaultValue = DefaultValue.Trim(),
				ListParams = ListParams.Trim()
			});

			var res = await _context.SaveChangesAsync();
			if (res > 0)
			{
				ViewBag.Mess = "Add event config success";
				return View();
			}

			return View();
		}

		[HttpGet]
		public IActionResult CreateAccount()
		{
			return View();
		}

		[HttpPost]
		public IActionResult CreateAccount([FromForm] string IdentityCode, [FromForm] string Username, [FromForm] string Password)
		{
			_context.Accounts.Add(new Account()
			{
				Id = Guid.NewGuid().ToString(),
				IdentityCode = IdentityCode.Trim(),
				Username = Username.Trim(),
				Password = Password
			});
			_context.SaveChanges();
			TempData["Message"] = "Create account success!Please create config for event";
			return RedirectToAction("Index");
		}

		[HttpGet]
		public IActionResult GetConfig()
		{
			var result = _context.Database
				.SqlQueryRaw<dynamic>(@"SELECT * FROM EventConfigurations");

			return Ok(result);
		}
	}
}
