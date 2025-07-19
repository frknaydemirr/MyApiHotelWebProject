using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WUI.ViewComponents.Default
{
    public class _ReservationPartial: ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
    
    }

