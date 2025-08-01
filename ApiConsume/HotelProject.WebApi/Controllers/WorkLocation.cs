﻿using HotelProject.BusinessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkLocationController : ControllerBase
    {
        private readonly IWorkLocationService _workLocationService;
        //verilerimi buradan örnek alacağım!

        public WorkLocationController(IWorkLocationService workLocationService)
        {
            _workLocationService = workLocationService;
        }

        [HttpGet]  //verileri getirmek için kullanılır.
        public IActionResult WorkLocationList()
        {
            var values = _workLocationService.TGetList();
            return Ok(values);
        }

        [HttpPost] //veri eklemek için kullanılır.

        public IActionResult AddWorkLocation(WorkLocation workLocation)
        {
            _workLocationService.TInsert(workLocation);


            return Ok();
        }
        [HttpDelete("{id}")]

        public IActionResult DeleteWorkLocation(int id)
        {
            var values = _workLocationService.TGetById(id);
            _workLocationService.TDelete(values);

            return Ok();
        }

        [HttpPut] //veri güncellemek için kullanılır.

        public IActionResult UpdateWorkLocation(WorkLocation workLocation)
        {
            _workLocationService.TUpdate(workLocation);
            return Ok();
        }

        [HttpGet("{id}")] //id ile veriyi getirmek için kullanılır.

        public IActionResult GetGuestById(int id)
        {
            var values = _workLocationService.TGetById(id);
            return Ok(values);
        }

    }
}
