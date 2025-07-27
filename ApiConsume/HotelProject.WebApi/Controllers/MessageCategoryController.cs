using HotelProject.BusinessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageCategoryController : ControllerBase
    {

        private readonly IMessageCategoryService _messageCategoryService;
        //verilerimi buradan örnek alacağım!

        public MessageCategoryController(IMessageCategoryService messageCategoryService)
        {
            _messageCategoryService = messageCategoryService;
        }

        [HttpGet]  //verileri getirmek için kullanılır.
        public IActionResult MessageCategoryList()
        {
            var values = _messageCategoryService.TGetList();
            return Ok(values);
        }

        [HttpPost] //veri eklemek için kullanılır.

        public IActionResult AddMessageCategory(MessageCategory messageCategory)
        {
            _messageCategoryService.TInsert(messageCategory);


            return Ok();
        }
        [HttpDelete("{id}")]

        public IActionResult DeleteMessageCategory(int id)
        {
            var values = _messageCategoryService.TGetById(id);
            _messageCategoryService.TDelete(values);

            return Ok();
        }

        [HttpPut] //veri güncellemek için kullanılır.

        public IActionResult UpdateMessageCategory(MessageCategory messageCategory)
        {
            _messageCategoryService.TUpdate(messageCategory);
            return Ok();
        }

        [HttpGet("{id}")] //id ile veriyi getirmek için kullanılır.

        public IActionResult GetMessageCategoryById(int id)
        {
            var values = _messageCategoryService.TGetById(id);
            return Ok(values);
        }
    }
}
