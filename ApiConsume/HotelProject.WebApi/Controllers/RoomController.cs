using HotelProject.BusinessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        //Api nin mutlaka hangi attribute ile çalışacağını belirtmemiz gerekiyor.


        private readonly IRoomService _roomService;
        //verilerimi buradan örnek alacağım!

        public RoomController(IRoomService roomService)
        {
            _roomService = roomService;
        }

        [HttpGet]  //verileri getirmek için kullanılır.
        public IActionResult RoomList()
        {
            var values = _roomService.TGetList();
            return Ok(values);
        }

        [HttpPost] //veri eklemek için kullanılır.

        public IActionResult AddRoom(Room room)
        {
            _roomService.TInsert(room);


            return Ok();
        }
        [HttpDelete]

        public IActionResult DeleteRoom(int id)
        {
            var values = _roomService.TGetById(id);
            _roomService.TDelete(values);

            return Ok();
        }

        [HttpPut] //veri güncellemek için kullanılır.

        public IActionResult UpdateRoom(Room room)
        {
            _roomService.TUpdate(room);
            return Ok();
        }

        [HttpGet("{id}")] //id ile veriyi getirmek için kullanılır.

        public IActionResult GetRoomById(int id)
        {
            var values = _roomService.TGetById(id);
            return Ok(values);
        }
    }
}
