using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WUI.ViewComponents.Booking
{
    public class _BookingCoverPartial :ViewComponent
    {

        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
