using HotelProject.BusinessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialController : ControllerBase
    {

        private readonly ITestimonialService _TestimonialService;
        //verilerimi buradan örnek alacağım!

        public TestimonialController(ITestimonialService TestimonialService)
        {
            _TestimonialService = TestimonialService;
        }

        [HttpGet]  //verileri getirmek için kullanılır.
        public IActionResult TestimonialList()
        {
            var values = _TestimonialService.TGetList();
            return Ok(values);
        }

        [HttpPost] //veri eklemek için kullanılır.

        public IActionResult AddTestimonial(Testimonial Testimonial)
        {
            _TestimonialService.TInsert(Testimonial);


            return Ok();
        }
        [HttpDelete]

        public IActionResult DeleteTestimonial(int id)
        {
            var values = _TestimonialService.TGetById(id);
            _TestimonialService.TDelete(values);

            return Ok();
        }

        [HttpPut] //veri güncellemek için kullanılır.

        public IActionResult UpdateTestimonial(Testimonial Testimonial)
        {
            _TestimonialService.TUpdate(Testimonial);
            return Ok();
        }

        [HttpGet("{id}")] //id ile veriyi getirmek için kullanılır.

        public IActionResult GetTestimonialById(int id)
        {
            var values = _TestimonialService.TGetById(id);
            return Ok(values);
        }
    }
}
