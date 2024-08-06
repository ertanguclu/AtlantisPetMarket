using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using EntityLayer.DbContexts;
using EntityLayer.Models.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AtlantisPetMarket.Controllers.ParentCategories
{
    public class BirdsController : Controller
    {
        private readonly IProductManager<AppDbContext, Product, int> _productManager;
        private readonly IParentCategoryManager<AppDbContext, ParentCategory, int> _parentCategoryManager;

        public BirdsController(IProductManager<AppDbContext, Product, int> productManager, IParentCategoryManager<AppDbContext, ParentCategory, int> parentCategoryManager)
        {
            _productManager = productManager;
            _parentCategoryManager = parentCategoryManager;
        }

        public async Task<IActionResult> Index()
        {
            var catCategory = await _parentCategoryManager.GetByAsync(pc => pc.ParentCategoryName == "Kuş");

            if (catCategory == null)
            {
                return NotFound();
            }

            var products = await _productManager.GetAllAsync(p => p.ParentCategoryId == catCategory.Id);

            return View(products);
        }
    }
}
