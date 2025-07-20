using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WUI.Controllers
{
    public class RoomController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
