using Microsoft.AspNetCore.Mvc;

namespace AtlantisPetMarket.Controllers.ParentCategories
{
    public class CatsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
