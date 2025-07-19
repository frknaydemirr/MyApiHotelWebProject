using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WUI.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
