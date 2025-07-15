using HotelProject.BusinessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubscribeController : ControllerBase
    {
        private readonly ISubscribeService _SubscribeService;
        //verilerimi buradan örnek alacağım!

        public SubscribeController(ISubscribeService SubscribeService)
        {
            _SubscribeService = SubscribeService;
        }

        [HttpGet]  //verileri getirmek için kullanılır.
        public IActionResult SubscribeList()
        {
            var values = _SubscribeService.TGetList();
            return Ok(values);
        }

        [HttpPost] //veri eklemek için kullanılır.

        public IActionResult AddSubscribe(Subcribe Subscribe)
        {
            _SubscribeService.TInsert(Subscribe);


            return Ok();
        }
        [HttpDelete]

        public IActionResult DeleteSubscribe(int id)
        {
            var values = _SubscribeService.TGetById(id);
            _SubscribeService.TDelete(values);

            return Ok();
        }

        [HttpPut] //veri güncellemek için kullanılır.

        public IActionResult UpdateSubscribe(Subcribe Subscribe)
        {
            _SubscribeService.TUpdate(Subscribe);
            return Ok();
        }

        [HttpGet("{id}")] //id ile veriyi getirmek için kullanılır.

        public IActionResult GetSubscribeById(int id)
        {
            var values = _SubscribeService.TGetById(id);
            return Ok(values);
        }
    }
}
