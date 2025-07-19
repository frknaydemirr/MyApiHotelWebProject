using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WUI.ViewComponents.Default
{
    public class _TrailerPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
