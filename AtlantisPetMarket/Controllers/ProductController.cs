using AtlantisPetMarket.Models.ProductVM;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using BusinessLayer.Abstract;
using EntityLayer.DbContexts;
using EntityLayer.Models.Concrete;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace AtlantisPetMarket.Controllers
{

    public class ProductController : Controller
    {
        private readonly AppDbContext _context;

        private readonly IProductManager<AppDbContext, Product, int> _productManager;
        private readonly ICategoryManager<AppDbContext, Category, int> _categoryManager;
        private readonly IParentCategoryManager<AppDbContext, ParentCategory, int> _parentCategoryManager;
        private readonly IMapper _mapper;
        private readonly IValidator<ProductUpdateVM> _validator;

        public ProductController(AppDbContext context, IProductManager<AppDbContext, Product, int> productManager,
            ICategoryManager<AppDbContext, Category, int> categoryManager, IParentCategoryManager<AppDbContext, ParentCategory, int> parentCategory, IMapper mapper, IValidator<ProductUpdateVM> validator)
        {
            _context = context;
            _productManager = productManager;
            _categoryManager = categoryManager;
            _parentCategoryManager = parentCategory;
            _mapper = mapper;
            _validator = validator;
        }

        //public async Task<ActionResult<IEnumerable<Product>>> Index(int id)
        //{
        //    var products = await _productManager.GetAllIncludeAsync(x => x.CategoryId == id, x => x.Category, x => x.ParentCategory);
        //    return View(products);
        //}

        //public ActionResult<IQueryable<Product>> Index(int id)
        //{
        //    var productsQuery = _productManager.GetAllInclude(
        //        x => x.CategoryId == id,
        //        x => x.Category,
        //        x => x.ParentCategory
        //    ).AsNoTracking();

        //    // Veritabanı sorgusunu hemen çalıştırmadan IQueryable döndürüyoruz
        //    return View(productsQuery);
        //}

        public IActionResult Index()
        {

            //#region Metod Syntax ile Queryable Sorgu olustuma
            //var products = _context.Products
            //                    .Include(p => p.Category)
            //                    .Include(p => p.ParentCategory)

            //                    .AsNoTracking() // Çekilen datayi izleme
            //                    .AsQueryable(); // Sorgu taslagi olarak ver


            //var products = _productManager.GetAllInclude(p=>p.Category,p=>p.ParentCategory);

            //var products = _productManager.GetProducts();
            //var productsvm = _mapper.Map<ProductListVM>(products);
            var productsVM = _productManager.GetProducts()
                                .ProjectTo<ProductListVM>(_mapper.ConfigurationProvider);

            return View(productsVM);


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

            productVM.Price = parsedPrice;

            //}
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
            return RedirectToAction("Index");
        }



        [HttpGet]
        public async Task<IActionResult> Update(int id, int? parentCategoryId)
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
        public async Task<IActionResult> Update(ProductUpdateVM productUpdateVM, int id)
        {

            var product = await _productManager.FindAsync(id);
            if (product == null)
            {
                // Eğer yeni bir resim seçilmemişse, mevcut resmi kullan
                product.ProductPhotoPath = productUpdateVM.ProductPhotoPath;
            }
            //var result = _validator.Validate(productUpdateVM);
            //if (!result.IsValid)
            //{
            //    return BadRequest(result.Errors);
            //}
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
