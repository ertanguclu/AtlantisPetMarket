using EntityLayer.DbContexts;
using Microsoft.AspNetCore.Mvc;

namespace Core_Proje.Areas.Writer.ViewComponents.Dashboard
{
    public class Statistics : ViewComponent
    {
        AppDbContext context = new AppDbContext();

        public IViewComponentResult Invoke()
        {
            ViewBag.KS = context.Users.Count();

            return View();
        }
    }
}
