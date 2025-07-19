using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WUI.ViewComponents.Default
{
    public class _SpinnerPartial:ViewComponent
    {

        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
