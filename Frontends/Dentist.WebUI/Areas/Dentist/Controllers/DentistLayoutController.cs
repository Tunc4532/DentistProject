using Microsoft.AspNetCore.Mvc;

namespace Dentist.WebUI.Areas.Dentist.Controllers
{
	[Area("Dentist")]
	[Route("Dentist/DentistLayout")]
	public class DentistLayoutController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
