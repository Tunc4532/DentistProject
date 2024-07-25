using Microsoft.AspNetCore.Mvc;

namespace Dentist.WebUI.Areas.Dentist.ViewComponents.DentistLayoutViewComponents
{
	public class _DentistLayoutSideBarComponentPartial : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
