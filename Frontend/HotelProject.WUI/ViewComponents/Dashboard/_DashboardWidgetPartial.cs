using HotelProject.WUI.Dtos.GuestDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace HotelProject.WUI.ViewComponents.Dashboard
{
    public class _DashboardWidgetPartial : ViewComponent
    {
        //consume işlemi için :

        private readonly IHttpClientFactory _httpClientFactory;

        public _DashboardWidgetPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task< IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient(); //istemciyi oluşturuyorum.
            var resposeMessage = await client.GetAsync("http://localhost:52704/api/DashboardWidgets/StaffCount"); //adresine istek atıyorum.
                var jsonData = await resposeMessage.Content.ReadAsStringAsync();
                //var values = JsonConvert.DeserializeObject<List<ResultGuestDto>>(jsonData);

                ViewBag.staffcount = jsonData;


            var client2 = _httpClientFactory.CreateClient(); //istemciyi oluşturuyorum.
            var resposeMessage2 = await client2.GetAsync("http://localhost:52704/api/DashboardWidgets/BookingCount"); //adresine istek atıyorum.
            var jsonData2 = await resposeMessage2.Content.ReadAsStringAsync();
            //var values = JsonConvert.DeserializeObject<List<ResultGuestDto>>(jsonData);

            ViewBag.bookingcount = jsonData2;

            var client3 = _httpClientFactory.CreateClient(); //istemciyi oluşturuyorum.
            var resposeMessage3 = await client3.GetAsync("http://localhost:52704/api/DashboardWidgets/AppUserCount"); //adresine istek atıyorum.
            var jsonData3 = await resposeMessage3.Content.ReadAsStringAsync();
            //var values = JsonConvert.DeserializeObject<List<ResultGuestDto>>(jsonData);

            ViewBag.appUserCount = jsonData3;

            var client4 = _httpClientFactory.CreateClient(); //istemciyi oluşturuyorum.
            var resposeMessage4 = await client4.GetAsync("http://localhost:52704/api/DashboardWidgets/RoomCount"); //adresine istek atıyorum.
            var jsonData4 = await resposeMessage4.Content.ReadAsStringAsync();
            //var values = JsonConvert.DeserializeObject<List<ResultGuestDto>>(jsonData);

            ViewBag.roomCount = jsonData4;

            return View();
        }


    }
}
