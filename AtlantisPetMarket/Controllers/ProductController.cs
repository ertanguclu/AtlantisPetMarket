using AtlantisPetMarket.Models.ProductVM;
using AutoMapper;
using BusinessLayer.Abstract;
using EntityLayer.DbContexts;
using EntityLayer.Models.Concrete;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;

namespace AtlantisPetMarket.Controllers
{
    
    public class ProductController : Controller
    {

        private readonly IProductManager<AppDbContext, Product, int> _productManager;
        private readonly ICategoryManager<AppDbContext, Category, int> _categoryManager;
        private readonly IParentCategoryManager<AppDbContext, ParentCategory, int> _parentCategoryManager;
        private readonly IMapper _mapper;
        private readonly IValidator<ProductUpdateVM> _validator;

        public ProductController(IProductManager<AppDbContext, Product, int> productManager,
            ICategoryManager<AppDbContext, Category, int> categoryManager, IParentCategoryManager<AppDbContext, ParentCategory, int> parentCategory, IMapper mapper, IValidator<ProductUpdateVM> validator)
        {
            _productManager = productManager;
            _categoryManager = categoryManager;
            _parentCategoryManager = parentCategory;
            _mapper = mapper;
            _validator = validator;
        }

        public async Task<ActionResult<IEnumerable<Product>>> Index(int id)
        {
            var products = await _productManager.GetAllIncludeAsync(x => x.CategoryId == id, x => x.Category, x => x.ParentCategory);
            return View(products);
        }
        [HttpGet]
        public async Task<IActionResult> GetCategoriesByParentId(int parentCategoryId)
        {
            var categories = await _categoryManager.GetAllAsync(c => c.ParentCategoryId == parentCategoryId);
            return Json(categories);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ProductInsertVM proudctInsertVM = new ProductInsertVM();
            ViewBag.categories = await _categoryManager.GetAllAsync(null);
            ViewBag.parentCategories = await _parentCategoryManager.GetAllAsync(null);
            return View(proudctInsertVM);

        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductInsertVM productVM, string price, int parentCategoryId)
        {
            if (!decimal.TryParse(price, NumberStyles.Any, CultureInfo.InvariantCulture, out var parsedPrice))
            {
                ModelState.AddModelError("Price", "Fiyat alanı geçerli bir sayı olmalıdır.");
                ViewBag.Categories = await _categoryManager.GetAllAsync(null);
                return View(productVM);
            }

            productVM.Price = parsedPrice;

            var product = _mapper.Map<Product>(productVM);

            if (productVM.ProductPhotoPath != null)
            {
                var resource = Directory.GetCurrentDirectory();
                var extension = Path.GetExtension(productVM.ProductPhotoPath.FileName);
                var imagename = Guid.NewGuid() + extension;
                var savelocation = Path.Combine(resource, "wwwroot", "productimage", imagename);
                using (var stream = new FileStream(savelocation, FileMode.Create))
                {
                    await productVM.ProductPhotoPath.CopyToAsync(stream);
                }
                product.ProductPhotoPath = imagename;
            }

            await _productManager.AddAsync(product);

            return RedirectToAction(nameof(Index));
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
            ViewBag.ParentCategories = await _parentCategoryManager.GetAllAsync(null);
            ParentCategory parentCategory = await _parentCategoryManager.FindAsync(product.ParentCategoryId);
            ViewBag.ParentCategoryName = parentCategory.ParentCategoryName;

            return View(viewModel);

        }
        [HttpPost]
        public async Task<IActionResult> Update(ProductUpdateVM productUpdateVM, string price)
        {
            #region my old code
            //if (!decimal.TryParse(price, NumberStyles.Any, CultureInfo.InvariantCulture, out var parsedPrice))
            //{
            //    ModelState.AddModelError("Price", "Fiyat alanı geçerli bir sayı olmalıdır.");
            //    ViewBag.Categories = await _categoryManager.GetAllAsync(c => c.ParentCategoryId == parentCategoryId);
            //    ViewBag.ParentCategoryId = parentCategoryId; // ParentCategoryId'yi ViewBag'e ekleyin
            //    return View(productUpdateVM);
            //}

            //productUpdateVM.Price = parsedPrice;

            //// Doğrulama
            //ValidationResult results = await _validator.ValidateAsync(productUpdateVM);

            //if (!results.IsValid)
            //{
            //    foreach (var failure in results.Errors)
            //    {
            //        ModelState.AddModelError(failure.PropertyName, failure.ErrorMessage);
            //    }
            //    ViewBag.Categories = await _categoryManager.GetAllAsync(c => c.ParentCategoryId == parentCategoryId);
            //    ViewBag.ParentCategoryId = parentCategoryId; // ParentCategoryId'yi ViewBag'e ekleyin
            //    return View(productUpdateVM);
            //}

            //var product = await _productManager.FindAsync(productUpdateVM.Id);
            //if (product == null)
            //{
            //    return NotFound();
            //}

            //product = _mapper.Map(productUpdateVM, product);
            //if (productUpdateVM.ProductPhotoUpdate != null && productUpdateVM.ProductPhotoUpdate == null)
            //{
            //    var resource = Directory.GetCurrentDirectory();
            //    var extension = Path.GetExtension(productUpdateVM.ProductPhotoUpdate.FileName);
            //    var imagename = Guid.NewGuid() + extension;
            //    var savelocation = Path.Combine(resource, "wwwroot", "productimage", imagename);
            //    using (var stream = new FileStream(savelocation, FileMode.Create))
            //    {
            //        await productUpdateVM.ProductPhotoUpdate.CopyToAsync(stream);
            //    }
            //    product.ProductPhotoPath = imagename;
            //}


            //await _productManager.UpdateAsync(product);
            //return RedirectToAction(nameof(Index)); 
            #endregion
            if (!decimal.TryParse(price, NumberStyles.Any, CultureInfo.InvariantCulture, out var parsedPrice))
            {
                ModelState.AddModelError("Price", "Fiyat alanı geçerli bir sayı olmalıdır.");
                ViewBag.Categories = await _categoryManager.GetAllAsync(null);
                return View(productUpdateVM);
            }

            productUpdateVM.Price = parsedPrice;

            var product = _mapper.Map<Product>(productUpdateVM);
            if (productUpdateVM.ProductPhotoUpdate != null)
            {
                var resource = Directory.GetCurrentDirectory();
                var extension = Path.GetExtension(productUpdateVM.ProductPhotoUpdate.FileName);
                var imagename = Guid.NewGuid() + extension;
                var savelocation = Path.Combine(resource, "wwwroot", "productimage", imagename);
                using (var stream = new FileStream(savelocation, FileMode.Create))
                {
                    await productUpdateVM.ProductPhotoUpdate.CopyToAsync(stream);
                }
                product.ProductPhotoPath = imagename;
            }
            else
            {
                // Eğer yeni bir resim seçilmemişse, mevcut resmi kullan
                product.ProductPhotoPath = productUpdateVM.ProductPhotoPath;
            }
            await _productManager.UpdateAsync(product);

            return RedirectToAction(nameof(Index));
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
