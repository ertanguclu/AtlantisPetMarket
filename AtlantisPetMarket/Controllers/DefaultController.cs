using BusinessLayer.Abstract;
using EntityLayer.DbContexts;
using EntityLayer.Models.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AtlantisPetMarket.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        private readonly IProductManager<AppDbContext, Product, int> _productManager;
        public DefaultController(IProductManager<AppDbContext, Product, int> productManager)
        {
            _productManager = productManager;
        }
        public IActionResult Index()
        {
            var products = _productManager.GetAllAsync(null);
            return View(products);
        }

        //public PartialViewResult HeaderPartial()
        //{
        //    return PartialView();
        //}
        //public PartialViewResult NavbarPartial()
        //{
        //    return PartialView();
        //}
        //[HttpGet]
        //public PartialViewResult SendMessage()
        //{
        //    return PartialView();
        //}

    }
}
