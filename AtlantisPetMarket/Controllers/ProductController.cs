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
        private readonly IValidator<Product> _validator;
        private readonly IProductManager<AppDbContext, Product, int> _productManager;
        private readonly ICategoryManager<AppDbContext, Category, int> _categoryManager;
        private readonly IMapper _mapper;
        public ProductController(IProductManager<AppDbContext, Product, int> productManager,
            ICategoryManager<AppDbContext, Category, int> categoryManager, IMapper mapper, IValidator<Product> validator)
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
        public async Task<ActionResult> Create(Product product)
        {
            var result = await _validator.ValidateAsync(product);

            if (!result.IsValid)
            {
                foreach (var error in result.Errors)
                {
                    Console.WriteLine($"Property: {error.PropertyName}, Error: {error.ErrorMessage}");
                }
                result.AddToModelState(ModelState, null);
                return View(product);
            }

            await _productManager.AddAsync(product);
            return RedirectToAction("Index");
        }
    }
}
