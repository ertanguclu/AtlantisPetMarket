using Microsoft.AspNetCore.Mvc;

namespace AtlantisPetMarket.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
