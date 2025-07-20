using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WUI.Controllers
{
    public class BookingController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
