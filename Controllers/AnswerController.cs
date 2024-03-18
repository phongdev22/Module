using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Module.Entities;
using System.Collections;

namespace Module.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AnswerController : ControllerBase
	{
		private readonly MyDbContext _db;
		public AnswerController(MyDbContext db)
		{
			_db = db;
		}

		[HttpGet]
		public IActionResult Index()
		{
			return Ok();
		}
	}
}
