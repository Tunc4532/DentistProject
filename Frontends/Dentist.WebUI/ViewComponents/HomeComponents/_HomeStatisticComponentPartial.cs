using Microsoft.AspNetCore.Mvc;

namespace Dentist.WebUI.ViewComponents.HomeComponents
{
	public class _HomeStatisticComponentPartial : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
