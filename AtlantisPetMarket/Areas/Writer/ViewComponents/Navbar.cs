
using EntityLayer.Models.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Core_Proje.Areas.Writer.ViewComponents
{
    public class Navbar : ViewComponent
    {
        private readonly UserManager<MyUser> _userManager;

        public Navbar(UserManager<MyUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.v = values.ImagePath;
            return View();
        }
    }
}
