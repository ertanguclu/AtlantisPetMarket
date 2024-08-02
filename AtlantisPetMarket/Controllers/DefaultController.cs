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
            return View();
        }
        public PartialViewResult HeaderPartial()
        {
            return PartialView();
        }
        public PartialViewResult CartModalPartial()
        {
            return PartialView();
        }

        public PartialViewResult ScriptPartial()
        {
            return PartialView();
        }
        public PartialViewResult SearchPartial()
        {
            return PartialView();
        }
        public PartialViewResult SvgPartial()
        {
            return PartialView();
        }
    }
}
