using AtlantisPetMarket.Areas.Writer.Models;
using EntityLayer.Models.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Core_Proje.Areas.Writer.Controllers
{

    [Area("Writer")]
    [Route("Writer/[controller]/[action]")]
    [AllowAnonymous]
    public class RegisterController : Controller
    {
        private readonly UserManager<MyUser> _userManager;

        public RegisterController(UserManager<MyUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(new UserRegisterViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Index(UserRegisterViewModel p)
        {

            MyUser w = new MyUser()
            {
                Name = p.Name,
                Surname = p.Surname,
                Email = p.Mail,
                UserName = p.UserName,
                //ImageUrl = p.ImageUrl
            };
            if (p.Password == p.ConfirmPassword && p.Password != null)
            {
                var result = await _userManager.CreateAsync(w, p.Password);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Login");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
            }

            return View(p);
        }
    }
}

