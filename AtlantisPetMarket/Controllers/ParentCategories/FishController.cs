using Microsoft.AspNetCore.Mvc;

namespace AtlantisPetMarket.Controllers.ParentCategories
{
    public class FishController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
