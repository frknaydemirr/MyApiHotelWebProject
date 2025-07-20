using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace HotelProject.DataAccessLayer.Concrete
{
    public class Context : IdentityDbContext<AppUser, AppRole, int>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-798VB1N\\MSSQLSERVERDEV;Initial Catalog=ApiDb;Integrated Security=True;");
        }

        // SQL'e yansıyacak olan tablolar
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Staff> Staffs { get; set; }
        public DbSet<Subcribe> Subcribes { get; set; }
        public DbSet<Testimonial> Testimonials { get; set; }

        public DbSet<About> Abouts { get; set; }

        public DbSet<Booking> Bookings { get; set; }
    }
}
