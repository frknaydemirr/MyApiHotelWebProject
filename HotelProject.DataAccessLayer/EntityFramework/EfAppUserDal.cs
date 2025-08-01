﻿using HotelProject.DataAccessLayer.Abstract;
using HotelProject.DataAccessLayer.Concrete;
using HotelProject.DataAccessLayer.Repositories;
using HotelProject.EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.DataAccessLayer.EntityFramework
{
    public class EfAppUserDal : GenericRepository<AppUser>, IAppUserDal
    {
        public EfAppUserDal(Context context) : base(context)
        {

        }

        public int AppUserCount()
        {
            var context = new Context();
            return context.Users.Count();
        }

        public List<AppUser> UsersListWithWorkLocations()
        {
            var context = new Context();
            var values = context.Users.Include(x => x.WorkLocation).ToList();
            return values;
        }

        public List<AppUser> _UserListWithWorkLocation()
        {
            var context = new Context();
            return context.Users.Include(x=>x.WorkLocation).ToList();
        }
    }
}
