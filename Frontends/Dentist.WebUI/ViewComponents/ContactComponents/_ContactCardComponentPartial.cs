using Microsoft.AspNetCore.Mvc;

namespace Dentist.WebUI.ViewComponents.ContactComponents
{
    public class _ContactCardComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
