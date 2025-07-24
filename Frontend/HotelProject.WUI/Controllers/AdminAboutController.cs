using HotelProject.WUI.Dtos.AboutDto;
using HotelProject.WUI.Dtos.BookingDto;
using HotelProject.WUI.Models.Staff;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.WUI.Controllers
{
    public class AdminAboutController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;


        public AdminAboutController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {

            var client = _httpClientFactory.CreateClient(); //istemciyi oluşturuyorum.
            var resposeMessage = await client.GetAsync("http://localhost:52704/api/About"); //adresine istek atıyorum.
            if (resposeMessage.IsSuccessStatusCode)
            {
                var jsonData = await resposeMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultAboutDto>>(jsonData);
                return View(values);

            }
            return View();
        }

        [HttpGet]
        //verileri al
        public async Task<IActionResult> UpdateAbout(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"http://localhost:52704/api/About/{id}");
            if ((responseMessage.IsSuccessStatusCode))
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync(); // json verisini string olarak alıyorum.
                var values = JsonConvert.DeserializeObject<UpdateAboutDto>(jsonData);
                // json verisini modelime dönüştürüyorum. listeleme yaptık
                //liste olarak almıyoruz çünkü tek bir staff ı güncelleyeceğiz.
                return View(values);
            }
            return View();
        }

        [HttpPost]
        //verileri güncelle
        public async Task<IActionResult> UpdateAbout(UpdateAboutDto model)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(model);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("http://localhost:52704/api/About", content);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View();
        }


    }
}
