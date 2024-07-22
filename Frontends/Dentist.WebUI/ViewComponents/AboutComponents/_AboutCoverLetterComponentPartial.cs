using Microsoft.AspNetCore.Mvc;

namespace Dentist.WebUI.ViewComponents.AboutComponents
{
	public class _AboutCoverLetterComponentPartial : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
