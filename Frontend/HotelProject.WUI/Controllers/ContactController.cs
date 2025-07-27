using HotelProject.EntityLayer.Concrete;
using HotelProject.WUI.Dtos.BookingDto;
using HotelProject.WUI.Dtos.ContactDto;
using HotelProject.WUI.Dtos.MessageCategoryDto;
using HotelProject.WUI.Dtos.RoomDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.WUI.Controllers
{

    [AllowAnonymous]
    public class ContactController : Controller
    {


        private readonly IHttpClientFactory _httpClientFactory;

        public ContactController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }


        public async Task< IActionResult > Index()
        {
            //consume işlemi:

            var client = _httpClientFactory.CreateClient(); //istemciyi oluşturuyorum.
            var resposeMessage = await client.GetAsync("http://localhost:52704/api/MessageCategory"); //adresine istek atıyorum.
            var jsonData = await resposeMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultMessageCategoryDto>>(jsonData);
             List<SelectListItem>values2=(from x in values
                                          select new SelectListItem
                                          {
                                              Text=x.MessageCategoryName,
                                              Value=x.MessageCategoryID.ToString()

                                          }).ToList();
            ViewBag.v = values2; 
            return View();


            
           
        }



        [HttpGet]
        public PartialViewResult SendMessage()
        {
           
            return PartialView();
        }

        [HttpPost]
        public async Task<IActionResult> SendMessage(CreateContactDto createContactDto)
        {
            createContactDto.Date = DateTime.Parse(DateTime.Now.ToShortDateString());

            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createContactDto);
            var StringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            await client.PostAsync("http://localhost:52704/api/Contact", StringContent);
            return RedirectToAction("Index", "Default");

        }

    }
}
