using Microsoft.AspNetCore.Mvc;

namespace Dentist.WebUI.Controllers
{
    public class UILayoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
