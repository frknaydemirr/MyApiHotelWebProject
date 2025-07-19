using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WUI.ViewComponents.Default
{
    public class _SubscribePartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
