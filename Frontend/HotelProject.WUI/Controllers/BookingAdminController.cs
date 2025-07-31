using HotelProject.WUI.Dtos.BookingDto;
using HotelProject.WUI.Dtos.GuestDto;
using HotelProject.WUI.Dtos.ServiceDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.WUI.Controllers
{
    public class BookingAdminController : Controller
    {
           
        //verilerimi listelemem lazım:

        private readonly IHttpClientFactory _httpClientFactory;


        public BookingAdminController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {

            var client = _httpClientFactory.CreateClient(); //istemciyi oluşturuyorum.
            var resposeMessage = await client.GetAsync("http://localhost:52704/api/Booking"); //adresine istek atıyorum.
            if (resposeMessage.IsSuccessStatusCode)
            {
                var jsonData = await resposeMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultBookingDto>>(jsonData);
                return View(values);

            }
            return View();
        }









        public async Task<IActionResult> ApprovedReservation(ApprovedReservationDto approvedReservationDto)
        {

            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(approvedReservationDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("http://localhost:52704/api/bbb", stringContent);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View();
        }

        public async Task<IActionResult> CancelReservation(int id)
        {
            //adresi tetiklemek için kullanıyorum.
            var client = _httpClientFactory.CreateClient();

            var responseMessage = await client.GetAsync($"http://localhost:52704/api/Booking/BookingCancel?id={id}");

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View();
        }


        public async Task<IActionResult> WaitReservation(int id)
        {
            //adresi tetiklemek için kullanıyorum.
            var client = _httpClientFactory.CreateClient();

            var responseMessage = await client.GetAsync($"http://localhost:52704/api/Booking/BookingWait?id={id}");

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View();
        }


        [HttpGet]
        public async Task<IActionResult> UpdateBooking(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var resposeMessage = await client.GetAsync($"http://localhost:52704/api/Booking/{id}");

            if (resposeMessage.IsSuccessStatusCode)
            {
                var jsonData = await resposeMessage.Content.ReadAsStringAsync();

                
                var value = JsonConvert.DeserializeObject<UpdateBookingDto>(jsonData);

                return View(value);
            }

            return View();
        }


        [HttpPost]
        //verileri güncelle
        public async Task<IActionResult> UpdateBooking(UpdateBookingDto updateBookingDto)
        {

                var client = _httpClientFactory.CreateClient();
                var jsonData = JsonConvert.SerializeObject(updateBookingDto);
                var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                var responseMessage = await client.PutAsync("http://localhost:52704/api/Booking/UpdateBooking/", content);

                if (responseMessage.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                return View();
           
            
        }

        public async Task<IActionResult> ApprovedReservation2(int id)
        {
            //adresi tetiklemek için kullanıyorum.
            var client = _httpClientFactory.CreateClient();
        
            var responseMessage = await client.GetAsync($"http://localhost:52704/api/Booking/BookingApproved?id={id}");

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View();
        }



    }
}
