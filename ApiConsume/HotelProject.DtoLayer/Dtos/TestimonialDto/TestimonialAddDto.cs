﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.DtoLayer.Dtos.TestimonialDto
{
    public  class TestimonialAddDto
    {


        public int TestimonialID { get; set; }

        public string Name { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }

        public string Image { get; set; }
    }
}
