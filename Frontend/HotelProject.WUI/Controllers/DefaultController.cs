using HotelProject.WUI.Dtos.ServiceDto;
using HotelProject.WUI.Dtos.SubscribeDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.WUI.Controllers
{
    //Anasayfa
    public class DefaultController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public DefaultController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public PartialViewResult _SubscribePartial()
        {
            return PartialView();
        }


        [HttpPost]
        public async Task<IActionResult> _SubscribePartial(CreateSubscribeDto createSubscribeDto)
        {

            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createSubscribeDto);
            var StringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
           await client.PostAsync("http://localhost:52704/api/Subscribe", StringContent);
           return RedirectToAction("Index","Default");

        }
    }
}
