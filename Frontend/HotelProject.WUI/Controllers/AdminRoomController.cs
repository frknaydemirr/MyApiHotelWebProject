using HotelProject.WUI.Dtos.RoomDto;
using HotelProject.WUI.Models.Staff;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.WUI.Controllers
{
    public class AdminRoomController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;


        public AdminRoomController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {

            var client = _httpClientFactory.CreateClient(); //istemciyi oluşturuyorum.
            var resposeMessage = await client.GetAsync("http://localhost:52704/api/Room"); //adresine istek atıyorum.
            if (resposeMessage.IsSuccessStatusCode)
            {
                var jsonData = await resposeMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultRoomDto>>(jsonData);
                return View(values);

            }
            return View();
        }

        [HttpGet]
        public IActionResult AddRoom()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddRoom(CreateRoomDto createRoomDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createRoomDto);
            var StringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("http://localhost:52704/api/Room", StringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();

        }

        public async Task<IActionResult> DeleteRoom(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"http://localhost:52704/api/Room/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        //verileri al
        public async Task<IActionResult> UpdateRoom(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"http://localhost:52704/api/Room/{id}");
            if ((responseMessage.IsSuccessStatusCode))
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync(); // json verisini string olarak alıyorum.
                var values = JsonConvert.DeserializeObject<UpdateRoomDto>(jsonData);
                // json verisini modelime dönüştürüyorum. listeleme yaptık
                //liste olarak almıyoruz çünkü tek bir staff ı güncelleyeceğiz.
                return View(values);
            }
            return View();
        }
        [HttpPost]
        //verileri güncelle
        public async Task<IActionResult> UpdateRoom(UpdateRoomDto updateRoomDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateRoomDto);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("http://localhost:52704/api/Room", content);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View(updateRoomDto);
        }
    }
}
