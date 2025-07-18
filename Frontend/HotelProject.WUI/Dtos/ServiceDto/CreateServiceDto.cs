using System.ComponentModel.DataAnnotations;

namespace HotelProject.WUI.Dtos.ServiceDto
{
    public class CreateServiceDto
    {

        [Required(ErrorMessage = "Hizmet İcon Linki Giriniz:")]
        public string ServiceIcon { get; set; }

        [Required(ErrorMessage = "Hizmet Başlığı Giriniz:")]

        [StringLength(100, ErrorMessage = "Hizmet Başlığı  en fazla 100 karakter olmalıdır.")]
        public string Title { get; set; }


        public string Description { get; set; }
    }
}
