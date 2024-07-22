using Microsoft.AspNetCore.Mvc;

namespace Dentist.WebUI.ViewComponents.HomeComponents
{
	public class _HomeMakeAnAppointmentComponentPartial : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
