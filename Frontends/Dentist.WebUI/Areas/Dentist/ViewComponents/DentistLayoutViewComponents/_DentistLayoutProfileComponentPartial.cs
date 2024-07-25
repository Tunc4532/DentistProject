using Microsoft.AspNetCore.Mvc;

namespace Dentist.WebUI.Areas.Dentist.ViewComponents.DentistLayoutViewComponents
{
	public class _DentistLayoutProfileComponentPartial : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
