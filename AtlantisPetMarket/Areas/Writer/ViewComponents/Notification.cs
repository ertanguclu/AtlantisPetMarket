using EntityLayer.Models.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Core_Proje.Areas.Writer.ViewComponents
{
    public class Notification : ViewComponent
    {

        private readonly UserManager<MyUser> _userManager;

        public Notification(UserManager<MyUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.UserImage = user.ImagePath;



            return View();
        }
    }
}
