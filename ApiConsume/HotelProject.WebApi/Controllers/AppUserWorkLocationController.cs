using HotelProject.BusinessLayer.Abstract;
using HotelProject.DataAccessLayer.Concrete;
using HotelProject.WebApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppUserWorkLocationController : ControllerBase
    {
        private readonly IAppUserService _appUserService;

        public AppUserWorkLocationController(IAppUserService appUserService)
        {
            _appUserService = appUserService;
        }
        //verilerin apide tekrarlı gelmesini engelledik!
        [HttpGet]
        public IActionResult Index()
        {//bunun üzerine tartış,araştır ve sor!!!!
            //var values= _appUserService.TUsersListWithWorkLocations();
            Context context = new Context();
            var values = context.Users.Include(x=>x.WorkLocation).Select(y=>new AppUserWorkLocationViewModel {

               Name= y.Name,
               Surname = y.Surname,
                WorkLocationName = y.WorkLocation.WorkLocationCityName,
                WorkLocationID = y.WorkLocationID,
                City= y.City,
                Country = y.Country,
                Gender = y.Gender,
                ImageUrl = y.ImageUrl
            }).ToList();
        
            return Ok(values);
        }

    }
}
