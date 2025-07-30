using HotelProject.WUI.Dtos.BookingDto;
using HotelProject.WUI.Dtos.GuestDto;
using HotelProject.WUI.Dtos.StaffDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace HotelProject.WUI.ViewComponents.Dashboard
{
    public class _DashboardLastFourStaffList:ViewComponent
    {

        private readonly IHttpClientFactory _httpClientFactory;


        public _DashboardLastFourStaffList(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        //listeleme işlemi
        public async Task<IViewComponentResult> InvokeAsync()
        {

            var client = _httpClientFactory.CreateClient(); //istemciyi oluşturuyorum.
            var resposeMessage = await client.GetAsync("http://localhost:52704/api/Staff/LastFourStaff"); //adresine istek atıyorum.
            if (resposeMessage.IsSuccessStatusCode)
            {
                var jsonData = await resposeMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultLastFourStaffDto>>(jsonData);
                return View(values);

            }
            return View();
        }


    }
}
