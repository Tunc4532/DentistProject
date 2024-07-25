using Microsoft.AspNetCore.Mvc;

namespace Dentist.WebUI.Areas.Patient.Controllers
{
	[Area("Patient")]
	[Route("Patient/Dashboard")]
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
