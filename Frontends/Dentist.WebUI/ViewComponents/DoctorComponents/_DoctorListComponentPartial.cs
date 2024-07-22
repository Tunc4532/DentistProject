using Microsoft.AspNetCore.Mvc;

namespace Dentist.WebUI.ViewComponents.DoctorComponents
{
    public class _DoctorListComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
