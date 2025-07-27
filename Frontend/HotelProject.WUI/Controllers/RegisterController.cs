using HotelProject.EntityLayer.Concrete;
using HotelProject.WUI.Dtos.RegisterDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HotelProject.WUI.Controllers
{
    [AllowAnonymous]
    public class RegisterController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public RegisterController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        //metot asenkron olacak çünkü içerisinde asenkron yapılar olacak!
        [HttpPost]
        public async Task<IActionResult> Index(CreateNewUserDto createNewUserDto)
        {
            if(!ModelState.IsValid)
            {
                return View();
            }
            var appUser= new AppUser
            {
                Name = createNewUserDto.Name,
                Surname = createNewUserDto.Surname,
                UserName = createNewUserDto.Username,
                Email = createNewUserDto.Mail
            };
            var result= await _userManager.CreateAsync(appUser, createNewUserDto.Password);
            //bu metot identity kütüphanesine yeni bir kayıt oluşturmak için kullanılır.
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Login");
            }
            return View();
        }
    }
}
