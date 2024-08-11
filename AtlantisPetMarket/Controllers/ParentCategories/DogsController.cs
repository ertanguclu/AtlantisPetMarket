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
    public class DogsController : Controller
    {
        private readonly IProductManager<AppDbContext, Product, int> _productManager;
        private readonly IParentCategoryManager<AppDbContext, ParentCategory, int> _parentCategoryManager;
        private readonly IMapper _mapper;

        public DogsController(IProductManager<AppDbContext, Product, int> productManager, IParentCategoryManager<AppDbContext, ParentCategory, int> parentCategoryManager, IMapper mapper)
        {
            _productManager = productManager;
            _parentCategoryManager = parentCategoryManager;
            _mapper = mapper;

        }

        public async Task<IActionResult> Index()
        {
            var dogsCategory = await _parentCategoryManager.GetByAsync(pc => pc.ParentCategoryName.ToLower() == "köpek");

            if (dogsCategory == null)
            {
                return NotFound();
            }

            var products = await _productManager.GetAllAsync(p => p.ParentCategoryId == dogsCategory.Id);
            var dogViewModel = _mapper.Map<IEnumerable<ProductListVM>>(products);

            return View(dogViewModel);
        }
    }
}
