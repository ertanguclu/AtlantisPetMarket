using AtlantisPetMarket.Models;
using AutoMapper;
using BusinessLayer.Abstract;
using EntityLayer.DbContexts;
using EntityLayer.Models.Concrete;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;

namespace AtlantisPetMarket.Controllers
{

    public class ProductController : Controller
    {
        private readonly IValidator<ProductInsertVM> _validator;
        private readonly IProductManager<AppDbContext, Product, int> _productManager;
        private readonly ICategoryManager<AppDbContext, Category, int> _categoryManager;
        private readonly IMapper _mapper;
        public ProductController(IProductManager<AppDbContext, Product, int> productManager,
            ICategoryManager<AppDbContext, Category, int> categoryManager, IMapper mapper, IValidator<ProductInsertVM> validator)
        {
            _productManager = productManager;
            _categoryManager = categoryManager;
            _validator = validator;
            _mapper = mapper;
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
        public async Task<ActionResult<Product>> Create(ProductInsertVM productVM)
        {
            var product = _mapper.Map<Product>(productVM);
            var result = _validator.Validate(productVM);
            result.AddToModelState(this.ModelState);
            if (!ModelState.IsValid)
            {
                return BadRequest(product);
            }

            await _productManager.AddAsync(product);
            return RedirectToAction("Index");
        }
    }
}
