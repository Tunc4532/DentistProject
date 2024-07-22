using Microsoft.AspNetCore.Mvc;

namespace Dentist.WebUI.ViewComponents.HomeComponents
{
	public class _HomeSliderComponentPartial : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
