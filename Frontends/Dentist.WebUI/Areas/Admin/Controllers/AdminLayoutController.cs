using Microsoft.AspNetCore.Mvc;

namespace Dentist.WebUI.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Route("Admin/AdminLayout")]
	public class AdminLayoutController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
