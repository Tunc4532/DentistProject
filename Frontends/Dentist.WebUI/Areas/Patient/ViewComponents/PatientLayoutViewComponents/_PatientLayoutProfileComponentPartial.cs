using Microsoft.AspNetCore.Mvc;

namespace Dentist.WebUI.Areas.Patient.ViewComponents.PatientLayoutViewComponents
{
	public class _PatientLayoutProfileComponentPartial : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
