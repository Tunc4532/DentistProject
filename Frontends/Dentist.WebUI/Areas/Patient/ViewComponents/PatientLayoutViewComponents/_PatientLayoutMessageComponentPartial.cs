using Microsoft.AspNetCore.Mvc;

namespace Dentist.WebUI.Areas.Patient.ViewComponents.PatientLayoutViewComponents
{
	public class _PatientLayoutMessageComponentPartial : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
