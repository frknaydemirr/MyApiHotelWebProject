﻿using HotelProject.DataAccessLayer.Abstract;
using HotelProject.DataAccessLayer.Concrete;
using HotelProject.DataAccessLayer.Repositories;
using HotelProject.EntityLayer.Concrete;
using System;
using System.Linq;

namespace HotelProject.DataAccessLayer.EntityFramework
{
    public class EfBookingDal : GenericRepository<Booking>, IBookingDal
    {
        public EfBookingDal(Context context) : base(context)
        {

        }

        public void BookingStatusChangeApproved(Booking booking)
        {
            using var context = new Context(); 

            var values = context.Bookings.FirstOrDefault(x => x.BookingID == booking.BookingID);

            if (values != null)
            {
                values.Status = "Onaylandı";
                context.SaveChanges();
            }
            else
            {
                // Hata logla ya da exception fırlat
                throw new Exception("Booking bulunamadı.");
            }
        }

        public void BookingStatusChangeApproved2(int id)
        {
             var context = new Context();

            var values = context.Bookings.Find(id);
            values.Status = "Onaylandı";
            context.SaveChanges();

        }
    }
}
