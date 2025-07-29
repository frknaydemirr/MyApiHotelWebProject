using HotelProject.EntityLayer.Concrete;
using HotelProject.WUI.Dtos.AppUserDto;
using HotelProject.WUI.Dtos.RoomDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace HotelProject.WUI.Controllers
{
    
    public class AdminUsersController : Controller
    {
       

        private readonly IHttpClientFactory _httpClientFactory;


        public AdminUsersController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }



        public async Task<IActionResult> Index()
        {

        //    var client = _httpClientFactory.CreateClient(); //istemciyi oluşturuyorum.
        //    var resposeMessage = await client.GetAsync("http://localhost:52704/api/AppUser"); //adresine istek atıyorum.
        //    if (resposeMessage.IsSuccessStatusCode)
        //    {
        //        var jsonData = await resposeMessage.Content.ReadAsStringAsync();
        //        var values = JsonConvert.DeserializeObject<List<ResultAppUserDto>>(jsonData);
        //        return View(values);

        //    }
            return View();
        }

        public async Task<IActionResult> UserList()
        {

            var client = _httpClientFactory.CreateClient(); //istemciyi oluşturuyorum.
            var resposeMessage = await client.GetAsync("http://localhost:52704/api/AppUser"); //adresine istek atıyorum.
            if (resposeMessage.IsSuccessStatusCode)
            {
                var jsonData = await resposeMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultAppUserListDto>>(jsonData);
                return View(values);

            }
            return View();
        }



    }
}
