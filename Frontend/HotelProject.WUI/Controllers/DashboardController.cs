using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WUI.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
