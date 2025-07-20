using AutoMapper;
using HotelProject.EntityLayer.Concrete;
using HotelProject.WUI.Dtos.AboutDto;
using HotelProject.WUI.Dtos.LoginDto;
using HotelProject.WUI.Dtos.RegisterDto;
using HotelProject.WUI.Dtos.ServiceDto;
using HotelProject.WUI.Dtos.StaffDto;
using HotelProject.WUI.Dtos.SubscribeDto;
using HotelProject.WUI.Dtos.TestimonialDto;

namespace HotelProject.WUI.Mapping
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<ResultServiceDto, Service>().ReverseMap();
            CreateMap<UpdateServiceDto, Service>().ReverseMap();
            CreateMap<CreateServiceDto, Service>().ReverseMap();

            CreateMap<CreateNewUserDto, AppUser>().ReverseMap();

            CreateMap<LoginUserDto, AppUser>().ReverseMap();

            CreateMap<ResultAboutDto, About>().ReverseMap();
            CreateMap<UpdateAboutDto, About>().ReverseMap();

            CreateMap<ResultTestimonialDto, Testimonial>().ReverseMap();

            CreateMap<ResultStaffDto, Staff>().ReverseMap();

            CreateMap<CreateSubscribeDto, Subcribe>().ReverseMap();

        }

    }
}
