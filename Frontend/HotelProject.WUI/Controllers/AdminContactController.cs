﻿using HotelProject.WUI.Dtos.ContactDto;
using HotelProject.WUI.Dtos.SendMessageDto;
using HotelProject.WUI.Models.Staff;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.WUI.Controllers
{
    public class AdminContactController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;


        public AdminContactController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Inbox()
        {

            var client = _httpClientFactory.CreateClient(); //istemciyi oluşturuyorum.
            var resposeMessage = await client.GetAsync("http://localhost:52704/api/Contact"); //adresine istek atıyorum.
            if (resposeMessage.IsSuccessStatusCode)
            {
                var jsonData = await resposeMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<InboxContactDto>>(jsonData);
                return View(values);

            }
            return View();
        }

        public async Task<IActionResult> SendBox()
        {

            var client = _httpClientFactory.CreateClient(); //istemciyi oluşturuyorum.
            var resposeMessage = await client.GetAsync("http://localhost:52704/api/SendMessage"); //adresine istek atıyorum.
            if (resposeMessage.IsSuccessStatusCode)
            {
                var jsonData = await resposeMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultSendBoxDto>>(jsonData);
                return View(values);

            }
            return View();
        }



        [HttpGet]
        public IActionResult AddSendMessage()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddSendMessage(CreateSendMessage createSendMessage)
        {
            createSendMessage.SenderMail = "admin@gmail.com";
            createSendMessage.SenderName = "admin";
            createSendMessage.Date = DateTime.Parse(DateTime.Now.ToShortDateString());
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createSendMessage);
            var StringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("http://localhost:52704/api/SendMessage", StringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("SendBox");
            }
            return View();


        }



        public PartialViewResult SidebarAdminContactPartial()
        {
            return PartialView();

        }
             public PartialViewResult SidebarAdminContactCategoryPartial()
        {

            return PartialView();
        }

        public async Task< IActionResult > MessageDetailsBySendbox(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"http://localhost:52704/api/SendMessage/{id}");
            if ((responseMessage.IsSuccessStatusCode))
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync(); // json verisini string olarak alıyorum.
                var values = JsonConvert.DeserializeObject<GetMessageByIDDto>(jsonData);
                // json verisini modelime dönüştürüyorum. listeleme yaptık
                //liste olarak almıyoruz çünkü tek bir staff ı güncelleyeceğiz.
                return View(values);
            }
            return View();
        }

        public async Task<IActionResult> MessageDetailsByInbox(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"http://localhost:52704/api/Contact/{id}");
            if ((responseMessage.IsSuccessStatusCode))
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync(); // json verisini string olarak alıyorum.
                var values = JsonConvert.DeserializeObject<InboxContactDto>(jsonData);
                // json verisini modelime dönüştürüyorum. listeleme yaptık
                //liste olarak almıyoruz çünkü tek bir staff ı güncelleyeceğiz.
                return View(values);
            }
            return View();
        }

    }
}
