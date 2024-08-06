using AtlantisPetMarket.Models.ProductVM;
using AutoMapper;
using BusinessLayer.Abstract;
using EntityLayer.DbContexts;
using EntityLayer.Models.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace AtlantisPetMarket.Controllers.ParentCategories
{
    public class BirdsController : Controller
    {

        private readonly IProductManager<AppDbContext, Product, int> _productManager;
        private readonly IParentCategoryManager<AppDbContext, ParentCategory, int> _parentCategoryManager;
        private readonly IMapper _mapper;
        public BirdsController(IProductManager<AppDbContext, Product, int> productManager, IParentCategoryManager<AppDbContext, ParentCategory, int> parentCategoryManager, IMapper mapper)
        {
            _productManager = productManager;
            _mapper = mapper;
            _parentCategoryManager = parentCategoryManager;

        }
        public async Task<ActionResult<IEnumerable<Category>>> Index(int id)
        {
            var birdProducts = await _productManager.GetAllIncludeAsync(x => x.ParentCategoryId == id, x => x.ParentCategory);
            var viewModels = _mapper.Map<IEnumerable<ProductListVM>>(birdProducts);
            return View(viewModels);
        }
    }
}
