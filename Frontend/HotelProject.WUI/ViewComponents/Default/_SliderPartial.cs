using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WUI.ViewComponents.Default
{
    public class _SliderPartial:ViewComponent
    {

        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
