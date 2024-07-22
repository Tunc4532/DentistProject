using Microsoft.AspNetCore.Mvc;

namespace Dentist.WebUI.Controllers
{
	public class OurServiceController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
