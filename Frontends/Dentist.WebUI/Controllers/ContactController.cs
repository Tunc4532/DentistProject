using Microsoft.AspNetCore.Mvc;

namespace Dentist.WebUI.Controllers
{
	public class ContactController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
