using Microsoft.AspNetCore.Mvc;

namespace Dentist.WebUI.Controllers
{
    public class DoctorController : Controller
    {
        
        public IActionResult Index()
        {
            return View();
        }
		
		public IActionResult DoctorSingle(int id)
        {
            return View();
        }
        
		public IActionResult BookAnAppointment(int id)
		{
			return View();
		}

	}
}
