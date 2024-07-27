using AtlantisPetMarket.Models.ProductVM;
using AutoMapper;
using BusinessLayer.Abstract;
using EntityLayer.DbContexts;
using EntityLayer.Models.Concrete;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace AtlantisPetMarket.Controllers
{

    public class ProductController : Controller
    {

        private readonly IProductManager<AppDbContext, Product, int> _productManager;
        private readonly ICategoryManager<AppDbContext, Category, int> _categoryManager;
        private readonly IMapper _mapper;
        private readonly IValidator<ProductUpdateVM> _validator;
        public ProductController(IProductManager<AppDbContext, Product, int> productManager,
            ICategoryManager<AppDbContext, Category, int> categoryManager, IMapper mapper, IValidator<ProductUpdateVM> validator)
        {
            _productManager = productManager;
            _categoryManager = categoryManager;
            _mapper = mapper;
            _validator = validator;
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
        public async Task<ActionResult> Create(ProductInsertVM productVM)
        {

            //var result = _validator.Validate(productVM);
            //if (!result.IsValid)
            //{
            //    return BadRequest(result.Errors);

            //}
            var product = _mapper.Map<Product>(productVM);
            await _productManager.AddAsync(product);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var product = await _productManager.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            var viewModel = _mapper.Map<ProductUpdateVM>(product);
            ViewBag.Categories = await _categoryManager.GetAllAsync(null);

            Category category = await _categoryManager.FindAsync(product.CategoryId);
            ViewBag.CategoryName = category.CategoryName;
            ViewBag.SelectedCategoryId = product.CategoryId;
            return View(viewModel);

        }
        [HttpPost]
        public async Task<IActionResult> Update(ProductUpdateVM productUpdateVM, int id)
        {
            var result = _validator.Validate(productUpdateVM);
            if (!result.IsValid)
            {
                return BadRequest(result.Errors);
            }
            // Model doğrulaması
            var validationResult = _validator.Validate(productUpdateVM);

            // Kategorileri tekrar ayarla
            ViewBag.Categories = await _categoryManager.GetAllAsync(null);
            ViewBag.SelectedCategoryId = productUpdateVM.CategoryId;

            if (!validationResult.IsValid)
            {
                // Hatalar varsa, geri dön ve hata mesajlarını göster
                return View(productUpdateVM);
            }

            // Ürünü bul
            var product = await _productManager.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            // Ürünün kategorisini al
            var category = await _categoryManager.FindAsync(product.CategoryId);
            ViewBag.CategoryName = category?.CategoryName ?? string.Empty;

            // Fiyatı string'den decimal'e dönüştür
            if (decimal.TryParse(productUpdateVM.PriceInput.Replace(',', '.'), out decimal price))
            {
                productUpdateVM.Price = price;
            }
            else
            {
                // Fiyat dönüşümü başarısızsa hata mesajı ekle
                ModelState.AddModelError("PriceInput", "Geçerli bir fiyat girin.");
                return View(productUpdateVM);
            }
            // Modeli güncelle
            _mapper.Map(productUpdateVM, product);
            await _productManager.UpdateAsync(product);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var product = await _productManager.FindAsync(id);
            if (product != null)
            {
                await _productManager.DeleteAsync(product);
            }
            return RedirectToAction("Index");
        }
    }
}
