using Microsoft.AspNetCore.Mvc;

namespace Dentist.WebUI.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Route("Admin/Dashboard")]
	public class DashboardController : Controller
	{
		[HttpGet]
		[Route("Index")]
		public IActionResult Index()
		{
			return View();
		}
	}
}
