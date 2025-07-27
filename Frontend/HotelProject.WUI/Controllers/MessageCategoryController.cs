using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WUI.Controllers
{
    public class MessageCategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
