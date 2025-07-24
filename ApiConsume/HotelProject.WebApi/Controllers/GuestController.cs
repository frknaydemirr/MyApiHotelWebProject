using HotelProject.BusinessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GuestController : ControllerBase
    {
        //Api nin mutlaka hangi attribute ile çalışacağını belirtmemiz gerekiyor.


        private readonly IGuestService _guestService;
        //verilerimi buradan örnek alacağım!

        public GuestController(IGuestService guestService)
        {
            _guestService = guestService;
        }

        [HttpGet]  //verileri getirmek için kullanılır.
        public IActionResult GuestList()
        {
            var values = _guestService.TGetList();
            return Ok(values);
        }

        [HttpPost] //veri eklemek için kullanılır.

        public IActionResult AddGuest(Guest guest)
        {
            _guestService.TInsert(guest);


            return Ok();
        }
        [HttpDelete("{id}")]

        public IActionResult DeleteGuest(int id)
        {
            var values = _guestService.TGetById(id);
            _guestService.TDelete(values);

            return Ok();
        }

        [HttpPut] //veri güncellemek için kullanılır.

        public IActionResult UpdateGuest(Guest guest)
        {
            _guestService.TUpdate(guest);
            return Ok();
        }

        [HttpGet("{id}")] //id ile veriyi getirmek için kullanılır.

        public IActionResult GetGuestById(int id)
        {
            var values = _guestService.TGetById(id);
            return Ok(values);
        }
    }
}
