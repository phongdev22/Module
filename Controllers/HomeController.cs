using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Module.Entities;
using System.Runtime.InteropServices;

namespace Module.Controllers
{
	public class HomeController : Controller
	{
		private readonly MyDbContext _context;
		public HomeController(MyDbContext context) {
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

			return Ok(result);
		}

		[HttpGet]
		public IActionResult GetConfig()
		{
			var result = _context.Database
				.SqlQueryRaw<dynamic>(@"SELECT * FROM EventConfiguration");

			return Ok(result);
		}
	}
}
