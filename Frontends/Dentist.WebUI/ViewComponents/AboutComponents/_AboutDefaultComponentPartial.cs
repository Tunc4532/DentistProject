using Microsoft.AspNetCore.Mvc;

namespace Dentist.WebUI.ViewComponents.AboutComponents
{
    public class _AboutDefaultComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
