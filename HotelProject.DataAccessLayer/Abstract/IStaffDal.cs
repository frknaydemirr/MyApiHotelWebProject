﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelProject.EntityLayer.Concrete;
namespace HotelProject.DataAccessLayer.Abstract
{
    public  interface IStaffDal:IGenericDal<Staff>
    {

        int  GetStaffCount();
        List<Staff> LastFourStaff();

    }
}
