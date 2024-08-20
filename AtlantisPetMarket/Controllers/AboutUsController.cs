using Microsoft.AspNetCore.Mvc;

namespace AtlantisPetMarket.Controllers
{
    public class AboutUsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
