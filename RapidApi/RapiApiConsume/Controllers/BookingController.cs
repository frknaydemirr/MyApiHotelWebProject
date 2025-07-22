using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RapiApiConsume.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace RapiApiConsume.Controllers
{
    public class BookingController : Controller
    {
        public async Task<IActionResult> Index()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://booking-com.p.rapidapi.com/v1/hotels/search?categories_filter_ids=class%3A%3A2%2Cclass%3A%3A4%2Cfree_cancellation%3A%3A1&adults_number=2&page_number=0&children_number=2&include_adjacency=true&children_ages=5%2C0&locale=en-gb&dest_type=city&filter_by_currency=AED&dest_id=-553173&order_by=popularity&units=metric&checkout_date=2025-10-15&room_number=1&checkin_date=2025-10-14"),
                Headers =
                {
                    { "x-rapidapi-key", "a36c6ee4cfmshc9269ffa9c21abfp187d19jsnaed6b4df9064" },
                    { "x-rapidapi-host", "booking-com.p.rapidapi.com" },
                },
            };

            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();

                // BookingApiViewModel yapına göre deserialize işlemi
                var rootclass = JsonConvert.DeserializeObject<Root>(body);

                // Eğer direkt result.results listesi varsa bu şekilde View'a gönderiyoruz
                return View(rootclass.result.ToList());
            }
        }
    }
}
