using HotelProject.WUI.Dtos.RoomDto;
using HotelProject.WUI.Dtos.WorkLocationDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.WUI.Controllers
{
    public class WorkLocationController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;


        public WorkLocationController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {

            var client = _httpClientFactory.CreateClient(); //istemciyi oluşturuyorum.
            var resposeMessage = await client.GetAsync("http://localhost:52704/api/WorkLocation"); //adresine istek atıyorum.
            if (resposeMessage.IsSuccessStatusCode)
            {
                var jsonData = await resposeMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultWorkLocationDto>>(jsonData);
                return View(values);

            }
            return View();
        }

        [HttpGet]
        public IActionResult AddWorkLocation()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddWorkLocation(CreateWorkLocationDto createWorkLocationDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createWorkLocationDto);
            var StringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("http://localhost:52704/api/WorkLocation", StringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();

        }

        public async Task<IActionResult> DeleteWorkLocation(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"http://localhost:52704/api/WorkLocation/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        //verileri al
        public async Task<IActionResult> UpdateWorkLocation(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"http://localhost:52704/api/WorkLocation/{id}");
            if ((responseMessage.IsSuccessStatusCode))
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync(); // json verisini string olarak alıyorum.
                var values = JsonConvert.DeserializeObject<UpdateWorkLocationDto>(jsonData);
                // json verisini modelime dönüştürüyorum. listeleme yaptık
                //liste olarak almıyoruz çünkü tek bir staff ı güncelleyeceğiz.
                return View(values);
            }
            return View();
        }
        [HttpPost]
        //verileri güncelle
        public async Task<IActionResult> UpdateWorkLocation(UpdateWorkLocationDto updateWorkLocationDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateWorkLocationDto);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("http://localhost:52704/api/WorkLocation", content);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View(updateWorkLocationDto);
        }
    }
}
