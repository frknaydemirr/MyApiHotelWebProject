using HotelProject.WUI.Dtos.BookingDto;
using HotelProject.WUI.Dtos.SubscribeDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.WUI.Controllers
{
    [AllowAnonymous] //adminle beraber çalışmayan sayfaları açabilmek için kullanırız!
    public class BookingController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public BookingController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public PartialViewResult AddBooking()
        {
            return PartialView();
        }

        [HttpPost]
        public async  Task<IActionResult> AddBookingAsync(CreateBookingDto createBookingDto)
        {
            createBookingDto.Status = "Onay Bekliyor";

            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createBookingDto);
            var StringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            await client.PostAsync("http://localhost:52704/api/Booking", StringContent);
            return RedirectToAction("Index", "Default");

        }
    }
}

