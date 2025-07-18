using HotelProject.BusinessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {

        private readonly IServiceService _serviceService;
        //verilerimi buradan örnek alacağım!

        public ServiceController(IServiceService serviceService)
        {
            _serviceService = serviceService;
        }

        [HttpGet]  //verileri getirmek için kullanılır.
        public IActionResult ServiceList()
        {
            var values = _serviceService.TGetList();
            return Ok(values);
        }

        [HttpPost] //veri eklemek için kullanılır.

        public IActionResult AddService(Service service)
        {
            _serviceService.TInsert(service);


            return Ok();
        }
        [HttpDelete("{id}")]

        public IActionResult DeleteService(int id)
        {
            var values = _serviceService.TGetById(id);
            _serviceService.TDelete(values);

            return Ok();
        }

        [HttpPut] //veri güncellemek için kullanılır.

        public IActionResult UpdateService(Service service)
        {
            _serviceService.TUpdate(service);
            return Ok();
        }

        [HttpGet("{id}")] //id ile veriyi getirmek için kullanılır.

        public IActionResult GetServiceById(int id)
        {
            var values = _serviceService.TGetById(id);
            return Ok(values);
        }
    }
}
