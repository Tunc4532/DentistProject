using Microsoft.AspNetCore.Mvc;

namespace Dentist.WebUI.Areas.Patient.ViewComponents.PatientLayoutViewComponents
{
	public class _PatientLayoutHeadComponentPartial : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
