﻿using HotelProject.BusinessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookingService;
        //verilerimi buradan örnek alacağım!

        public BookingController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        [HttpGet]  //verileri getirmek için kullanılır.
        public IActionResult BookingList()
        {
            var values = _bookingService.TGetList();
            return Ok(values);
        }

        [HttpPost] //veri eklemek için kullanılır.

        public IActionResult AddBooking(Booking booking)
        {
            _bookingService.TInsert(booking);


            return Ok();
        }
        [HttpDelete("{id}")]

        public IActionResult DeleteBooking(int id)
        {
            var values = _bookingService.TGetById(id);
            _bookingService.TDelete(values);

            return Ok();
        }

        [HttpPut("UpdateBooking")] //veri güncellemek için kullanılır.

        public IActionResult UpdateBooking(Booking booking)
        {
            _bookingService.TUpdate(booking);
            return Ok();
        }

        [HttpGet("{id}")] //id ile veriyi getirmek için kullanılır.

        public IActionResult GetBookingById(int id)
        {
            var values = _bookingService.TGetById(id);
            return Ok(values);
        }


        [HttpGet("BookingApproved")]
        public IActionResult BookingApproved(int id)
        {
            _bookingService.TBookingStatusChangeApproved3(id);
            return Ok();
        }


        [HttpGet("BookingCancel")]
        public IActionResult BookingCancel(int id)
        {
            _bookingService.TBookingStatusChangeCancel(id);
            return Ok();
        }


        [HttpGet("BookingWait")]
        public IActionResult BookingWait(int id)
        {
            _bookingService.TBookingStatusChangeWait(id);
            return Ok();
        }









        [HttpPut("aaaaaaaaa")]
        public IActionResult aaaaaaaaa(Booking booking)
        {
            _bookingService.TBookingStatusChangeApproved(booking);
            return Ok();
        }

        [HttpPut("bbb")]
        public IActionResult bbb(int id )
        {
            _bookingService.TBookingStatusChangeApproved2(id);
            return Ok();
        }

        [HttpGet("Last6Booking")]
        public IActionResult Last6Booking()
        {
           var values= _bookingService.TLast6Bookings();
            return Ok(values);

        }

    }
}

