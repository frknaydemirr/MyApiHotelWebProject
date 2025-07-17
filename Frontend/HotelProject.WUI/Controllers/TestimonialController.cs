using HotelProject.WUI.Models.Testimonial;
using HotelProject.WUI.Models.Testimonial;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.WUI.Controllers
{

    public class TestimonialController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private string jsonData;
        public TestimonialController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {

            var client = _httpClientFactory.CreateClient(); //istemciyi oluşturuyorum.
            var resposeMessage = await client.GetAsync("http://localhost:52704/api/Testimonial"); //adresine istek atıyorum.
            if (resposeMessage.IsSuccessStatusCode)
            {
                var jsonData = await resposeMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<TestimonialViewModel>>(jsonData);
                return View(values);

            }
            return View();
        }

        [HttpGet]
        public IActionResult AddTestimonial()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddTestimonial(TestimonialViewModel model)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(model);
            var StringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("http://localhost:52704/api/Testimonial", StringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();


        }

        [HttpDelete]
        public async Task<IActionResult> DeleteTestimonial(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"http://localhost:52704/api/Testimonial/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }


        //verileri al
        public async Task<IActionResult> UpdateTestimonial(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"http://localhost:52704/api/Testimonial/{id}");
            if ((responseMessage.IsSuccessStatusCode))
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync(); // json verisini string olarak alıyorum.
                var values = JsonConvert.DeserializeObject<TestimonialViewModel>(jsonData);
                // json verisini modelime dönüştürüyorum. listeleme yaptık
                //liste olarak almıyoruz çünkü tek bir Testimonial ı güncelleyeceğiz.
                return View(values);
            }
            return View();
        }

        [HttpPost]
        //verileri güncelle
        public async Task<IActionResult> UpdateTestimonial(TestimonialViewModel model)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(model);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("http://localhost:52704/api/Testimonial", content);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View(model);
        }
    }
}
