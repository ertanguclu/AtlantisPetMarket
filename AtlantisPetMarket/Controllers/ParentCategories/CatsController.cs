using BusinessLayer.Abstract;
using EntityLayer.DbContexts;
using EntityLayer.Models.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AtlantisPetMarket.Controllers.ParentCategories
{
    public class CatsController : Controller
    {
        private readonly IProductManager<AppDbContext, Product, int> _productManager;

        public CatsController(IProductManager<AppDbContext, Product, int> productManager)
        {
            _productManager = productManager;
        }

        public async Task<IActionResult> Index()
        {
            var products = await _productManager.GetAllAsync(null);
            return View(products);
        }
    }
}
