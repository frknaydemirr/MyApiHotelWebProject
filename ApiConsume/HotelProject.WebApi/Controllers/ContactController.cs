using HotelProject.BusinessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {

        private readonly IContactService _contactService;
        //verilerimi buradan örnek alacağım!

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        [HttpPost] //veri eklemek için kullanılır.
        public IActionResult AddBooking(Contact contact)
        {
            contact.Date=Convert.ToDateTime(DateTime.Now.ToString());
            _contactService.Insert(contact);
            return Ok();
        }

    }
}
