
using EntityLayer.Models.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Core_Proje.ViewComponents.AdminNavbar
{
    public class AdminSidebar : ViewComponent
    {
        private readonly UserManager<User> _userManager;

        public AdminSidebar(UserManager<User> userManager)
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
