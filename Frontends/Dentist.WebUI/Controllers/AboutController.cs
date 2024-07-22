using Microsoft.AspNetCore.Mvc;

namespace Dentist.WebUI.Controllers
{
	public class AboutController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
