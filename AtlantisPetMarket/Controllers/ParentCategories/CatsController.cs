using AutoMapper;
using BusinessLayer.Abstract;
using BusinessLayer.Models.CartViewModel;
using BusinessLayer.Models.ProductVM;
using EntityLayer.DbContexts;
using EntityLayer.Models.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace AtlantisPetMarket.Controllers.ParentCategories
{
    public class CatsController : Controller
    {
        private readonly IProductManager<AppDbContext, Product, int> _productManager;
        private readonly IParentCategoryManager<AppDbContext, ParentCategory, int> _parentCategoryManager;
        private readonly IMapper _mapper;

        public CatsController(IProductManager<AppDbContext, Product, int> productManager, IParentCategoryManager<AppDbContext, ParentCategory, int> parentCategoryManager, IMapper mapper)
        {
            _productManager = productManager;
            _parentCategoryManager = parentCategoryManager;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index(string? category)
        {
            var catCategory = await _parentCategoryManager.GetByAsync(pc => pc.ParentCategoryName.ToLower() == "kedi");

            if (catCategory == null)
            {
                return NotFound();
            }

            // Kategoriye göre filtreleme yap, eğer kategori parametresi boşsa tüm ürünleri getir
            var products = await _productManager.GetProductsByCategoryAsync(
                p => p.ParentCategoryId == catCategory.Id &&
                     (string.IsNullOrEmpty(category) || p.Category.CategoryName.ToLower() == category.ToLower()),
                p => p.Category
            );

            var catsViewModel = _mapper.Map<IEnumerable<ProductCartVM>>(products.ToList());

            return View(catsViewModel);
        }





    }
}
