using Microsoft.AspNetCore.Mvc;

namespace AtlantisPetMarket.Controllers
{
    public class OrderController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
