using BusinessLayer.Abstract;
using EntityLayer.DbContexts;
using EntityLayer.Models.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace AtlantisPetMarket.Controllers
{

    public class ProductController : Controller
    {
        private readonly IProductManager<AppDbContext, Product, int> _productManager;
        private readonly ICategoryManager<AppDbContext, Category, int> _categoryManager;

        public ProductController(
            IProductManager<AppDbContext, Product, int> productManager,
            ICategoryManager<AppDbContext, Category, int> categoryManager)
        {
            _productManager = productManager;
            _categoryManager = categoryManager;
        }


        public async Task<ActionResult<IEnumerable<Product>>> Index(int id)
        {

            var products = await _productManager.GetAllIncludeAsync(x => x.CategoryId == id, x => x.Category);
            return View(products);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult<Product>> Create(Product product)
        {
            await _productManager.AddAsync(product);
            return RedirectToAction("Index");
        }
    }
}
