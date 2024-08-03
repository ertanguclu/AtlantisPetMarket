using Microsoft.AspNetCore.Mvc;

namespace AtlantisPetMarket.Controllers.ParentCategories
{
    public class BirdsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
