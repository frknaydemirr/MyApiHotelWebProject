using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WUI.ViewComponents.Dashboard
{
    public class _DashboardHeadPartial : ViewComponent
    {

        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
