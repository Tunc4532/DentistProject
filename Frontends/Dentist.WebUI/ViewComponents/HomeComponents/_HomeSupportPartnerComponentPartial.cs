using Microsoft.AspNetCore.Mvc;

namespace Dentist.WebUI.ViewComponents.HomeComponents
{
	public class _HomeSupportPartnerComponentPartial : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
