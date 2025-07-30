using HotelProject.BusinessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaffController : ControllerBase
    {

        private readonly IStaffService _staffService;
        //verilerimi buradan örnek alacağım!

        public StaffController(IStaffService staffService)
        {
            _staffService = staffService;
        }

        [HttpGet]  //verileri getirmek için kullanılır.
        public IActionResult StaffList()
        {
            var values = _staffService.TGetList();
            return Ok(values);
        }

        [HttpPost] //veri eklemek için kullanılır.

        public IActionResult AddStaff(Staff staff)
        {
            _staffService.TInsert(staff);
            

            return Ok();
        }
        [HttpDelete("{id}")]

        public IActionResult DeleteStaff(int id)
        {
            var values = _staffService.TGetById(id);
            _staffService.TDelete(values);

            return Ok();
        }

        [HttpPut] //veri güncellemek için kullanılır.

        public IActionResult UpdateStaff(Staff staff)
        {
            _staffService.TUpdate(staff);
            return Ok();
        }

        [HttpGet("{id}")] //id ile veriyi getirmek için kullanılır.

        public IActionResult GetStaffById(int id)
        {
            var values = _staffService.TGetById(id);
            return Ok(values);
        }

        [HttpGet("LastFourStaff")]
        public IActionResult LastFourStaff()
        {
            var values = _staffService.TLastFourStaff();
            return Ok(values);
        }

    }
}
