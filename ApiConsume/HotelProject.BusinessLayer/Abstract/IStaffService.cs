﻿using HotelProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.BusinessLayer.Abstract
{
    public  interface IStaffService:IGenericService<Staff>
    {

        int TGetStaffCount();
        List<Staff> TLastFourStaff();
    }
}
