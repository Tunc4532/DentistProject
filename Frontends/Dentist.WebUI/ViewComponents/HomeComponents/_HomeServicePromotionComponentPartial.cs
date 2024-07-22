using Microsoft.AspNetCore.Mvc;

namespace Dentist.WebUI.ViewComponents.HomeComponents
{
	public class _HomeServicePromotionComponentPartial : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
