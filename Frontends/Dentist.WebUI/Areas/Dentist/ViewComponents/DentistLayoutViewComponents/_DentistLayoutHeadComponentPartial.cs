using Microsoft.AspNetCore.Mvc;

namespace Dentist.WebUI.Areas.Dentist.ViewComponents.DentistLayoutViewComponents
{
	public class _DentistLayoutHeadComponentPartial : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
