using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WUI.ViewComponents.Default
{
    public class _NavbarPartial:ViewComponent
    {

        public IViewComponentResult Invoke()
        {
            //view componenet partialler ->  shared -> viewda olacak
            return View();
        }
    }
}
