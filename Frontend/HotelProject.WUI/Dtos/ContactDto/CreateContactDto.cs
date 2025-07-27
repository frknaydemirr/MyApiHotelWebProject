using HotelProject.EntityLayer.Concrete;
using System;

namespace HotelProject.WUI.Dtos.ContactDto
{
    public class CreateContactDto
    {
        public int ContactID { get; set; }

        public string Name { get; set; }

        public string Mail { get; set; }

        public string Subject { get; set; }

        public string Message { get; set; }

        public int MessageCategoryID { get; set; }

    
        public DateTime Date { get; set; }

    }
}
