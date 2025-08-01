﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelProject.DataAccessLayer.Abstract;
using HotelProject.DataAccessLayer.Concrete;
using HotelProject.DataAccessLayer.Repositories;
using HotelProject.EntityLayer.Concrete;
namespace HotelProject.DataAccessLayer.EntityFramework
{
    public  class EfStaffDal:GenericRepository<Staff>, IStaffDal
    {
        public EfStaffDal(Context context) : base(context)
        {
                
        }

        public int GetStaffCount()
        {
            using (var context = new Context())
            {
                return context.Staffs.Count();
            }
        }

        public List<Staff> LastFourStaff()
        {
            using var context = new Context();
            var values = context.Staffs.OrderByDescending(x => x.StaffID).Take(4).ToList(); //z->a sıralama
            return values;



        }
    }
}
