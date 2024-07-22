using Microsoft.AspNetCore.Mvc;

namespace Dentist.WebUI.ViewComponents.AboutComponents
{
    public class _AboutServiceCardComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
