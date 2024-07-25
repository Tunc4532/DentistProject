using Microsoft.AspNetCore.Mvc;

namespace Dentist.WebUI.Areas.Patient.Controllers
{
	[Area("Patient")]
	[Route("Patient/PatientLayout")]
	public class PatientLayoutController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
