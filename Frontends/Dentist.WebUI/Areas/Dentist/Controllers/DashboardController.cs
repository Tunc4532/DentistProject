using Microsoft.AspNetCore.Mvc;

namespace Dentist.WebUI.Areas.Dentist.Controllers
{
	[Area("Dentist")]
	[Route("Dentist/Dashboard")]
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
