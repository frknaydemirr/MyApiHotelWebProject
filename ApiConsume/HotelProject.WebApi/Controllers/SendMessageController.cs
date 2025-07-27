using HotelProject.BusinessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SendMessageController : ControllerBase
    {
        private readonly ISendMessageService _sendMessageService;
        //verilerimi buradan örnek alacağım!

        public SendMessageController(ISendMessageService SendMessageService)
        {
            _sendMessageService = SendMessageService;
        }

        [HttpGet]  //verileri getirmek için kullanılır.
        public IActionResult SendMessageList()
        {
            var values = _sendMessageService.TGetList();
            return Ok(values);
        }

        [HttpPost] //veri eklemek için kullanılır.

        public IActionResult AddSendMessage(SendMessage sendMessage)
        {
            _sendMessageService.TInsert(sendMessage);


            return Ok();
        }
        [HttpDelete("{id}")]

        public IActionResult DeleteSendMessage(int id)
        {
            var values = _sendMessageService.TGetById(id);
            _sendMessageService.TDelete(values);

            return Ok();
        }

        [HttpPut] //veri güncellemek için kullanılır.

        public IActionResult UpdateSendMessage(SendMessage sendMessage)
        {
            _sendMessageService.TUpdate(sendMessage);
            return Ok();
        }

        [HttpGet("{id}")] //id ile veriyi getirmek için kullanılır.

        public IActionResult GetSendMessageById(int id)
        {
            var values = _sendMessageService.TGetById(id);
            return Ok(values);
        }
        [HttpGet("GetSendMessageCount")]
        public IActionResult GetSendMessageCount()
        {
            return Ok(_sendMessageService.TGetSendMessageCount());
        }
    }
}
