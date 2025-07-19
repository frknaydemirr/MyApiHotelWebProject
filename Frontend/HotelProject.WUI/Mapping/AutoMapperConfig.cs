using AutoMapper;
using HotelProject.EntityLayer.Concrete;
using HotelProject.WUI.Dtos.LoginDto;
using HotelProject.WUI.Dtos.RegisterDto;
using HotelProject.WUI.Dtos.ServiceDto;

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
        }

    }
}
