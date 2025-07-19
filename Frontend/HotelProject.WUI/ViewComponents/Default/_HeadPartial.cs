using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WUI.ViewComponents.Default
{
    public class _HeadPartial:ViewComponent
    {
        //view componenet partialler ->  shared -> viewda olacak
        
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
