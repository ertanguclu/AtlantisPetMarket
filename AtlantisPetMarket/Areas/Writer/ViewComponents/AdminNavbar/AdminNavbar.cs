using EntityLayer.Models.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Core_Proje.ViewComponents.AdminNavbar
{
    public class AdminNavbar : ViewComponent
    {
        private readonly UserManager<MyUser> _userManager;

        public AdminNavbar(UserManager<MyUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.v = values.ImagePath;
            ViewBag.v2 = values.Name + " " + values.Surname;
            return View();
        }
    }
}
