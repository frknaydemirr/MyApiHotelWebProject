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
    public  class EfSubscribeDal : GenericRepository<Subcribe>, ISubscribeDal
    {

        public EfSubscribeDal(Context context) : base(context)
        {
            
        }

    }
}
