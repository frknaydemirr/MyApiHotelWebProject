using System.ComponentModel.DataAnnotations;

namespace HotelProject.WUI.Dtos.ServiceDto
{
    public class UpdateServiceDto
    {
        public int ServiceId { get; set; }

        [Required(ErrorMessage = "Hizmet İcon Linki Giriniz:")]
        public string ServiceIcon { get; set; }

        [Required(ErrorMessage = "Hizmet Başlığı Giriniz:")]

        [StringLength(100, ErrorMessage = "Hizmet Başlığı  en fazla 100 karakter olmalıdır.")]
        public string Title { get; set; }


        [Required(ErrorMessage = "Hizmet Açıklaması  Giriniz:")]

        [StringLength(500, ErrorMessage = "Hizmet Açıklaması  en fazla 500 karakter olmalıdır.")]
        public string Description { get; set; }
    }
}
