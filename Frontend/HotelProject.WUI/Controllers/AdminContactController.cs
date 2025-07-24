using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WUI.Controllers
{
    public class AdminContactController : Controller
    {
        public IActionResult Inbox()
        {
            return View();
        }

        public PartialViewResult SidebarAdminContactPartial()
        {
            return PartialView();

        }
             public PartialViewResult SidebarAdminContactCategoryPartial()
        {

            return PartialView();
        }
    }
}
