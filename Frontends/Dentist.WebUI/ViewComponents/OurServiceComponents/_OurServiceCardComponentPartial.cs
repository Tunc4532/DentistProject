using Microsoft.AspNetCore.Mvc;

namespace Dentist.WebUI.ViewComponents.OurServiceComponents
{
    public class _OurServiceCardComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
