using BusinessLayer.Models.ProductVM;
using AutoMapper;
using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using EntityLayer.DbContexts;
using EntityLayer.Models.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AtlantisPetMarket.Controllers.ParentCategories
{
    public class FishController : Controller
    {
        private readonly IProductManager<AppDbContext, Product, int> _productManager;
        private readonly IParentCategoryManager<AppDbContext, ParentCategory, int> _parentCategoryManager;
        private readonly IMapper _mapper;

        public FishController(IProductManager<AppDbContext, Product, int> productManager, IParentCategoryManager<AppDbContext, ParentCategory, int> parentCategoryManager, IMapper mapper)
        {
            _productManager = productManager;
            _parentCategoryManager = parentCategoryManager;
            _mapper = mapper;

        }

        public async Task<IActionResult> Index()
        {
            var fishCategory = await _parentCategoryManager.GetByAsync(pc => pc.ParentCategoryName.ToLower() == "balık");

            if (fishCategory == null)
            {
                return NotFound();
            }

            var products = await _productManager.GetAllAsync(p => p.ParentCategoryId == fishCategory.Id);
            var fishViewModel = _mapper.Map<IEnumerable<ProductListVM>>(products);

            return View(fishViewModel);
        }
    }
}
