using AtlantisPetMarket.Models.CartViewModel;
using AtlantisPetMarket.Models.ProductVM;
using AutoMapper;
using BusinessLayer.Abstract;
using BusinessLayer.Models.ProductVM;
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
        private readonly IMapper _mapper;

        public BirdsController(IProductManager<AppDbContext, Product, int> productManager, IParentCategoryManager<AppDbContext, ParentCategory, int> parentCategoryManager, IMapper mapper)
        {
            _productManager = productManager;
            _parentCategoryManager = parentCategoryManager;
            _mapper = mapper;


        }

        public async Task<IActionResult> Index()
        {
            var birdCategory = await _parentCategoryManager.GetByAsync(pc => pc.ParentCategoryName.ToLower() == "kuş");

            if (birdCategory == null)
            {
                return NotFound();
            }

            var products = await _productManager.GetAllAsync(p => p.ParentCategoryId == birdCategory.Id);
            var birdViewModel = _mapper.Map<IEnumerable<ProductCartVM>>(products);

            return View(birdViewModel);
        }
    }
}
