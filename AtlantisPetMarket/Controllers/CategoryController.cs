 using AtlantisPetMarket.Models.CategoryVM;
using AutoMapper;
using BusinessLayer.Abstract;
using EntityLayer.DbContexts;
using EntityLayer.Models.Concrete;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Mysqlx.Crud;

namespace AtlantisPetMarket.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IProductManager<AppDbContext, Product, int> _productManager;
        private readonly ICategoryManager<AppDbContext, Category, int> _categoryManager;
        private readonly IParentCategoryManager<AppDbContext, ParentCategory, int> _parentCategoryManager;
        private readonly IMapper _mapper;
        private readonly IValidator<CategoryUpdateVM> _validator;
        public CategoryController(ICategoryManager<AppDbContext, Category, int> categoryManager,
            IProductManager<AppDbContext, Product, int> productManager, IParentCategoryManager<AppDbContext, ParentCategory, int> parentCategoryManager, IMapper mapper, IValidator<CategoryUpdateVM> validator)
        {
            _productManager = productManager;
            _categoryManager = categoryManager;
            _mapper = mapper;
            _validator = validator;
            _parentCategoryManager = parentCategoryManager;

        }
        public async Task<ActionResult<IEnumerable<Category>>> Index(int id)
        {
            var categories = await _categoryManager.GetAllIncludeAsync(x => x.ParentCategoryId == id, x => x.ParentCategory);
            return View(categories);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewBag.parentCategories = await _parentCategoryManager.GetAllAsync(null);
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Create(CategoryInsertVM insertVM)
        {

            //var result = _validator.Validate(productVM);
            //if (!result.IsValid)
            //{
            //    return BadRequest(result.Errors);

            //}
            var category = _mapper.Map<Category>(insertVM);

            if (insertVM.CategoryPhotoPath != null)
            {
                var resource = Directory.GetCurrentDirectory();
                var extension = Path.GetExtension(insertVM.CategoryPhotoPath.FileName);
                var imageName = Guid.NewGuid() + extension;
                var saveLocation = Path.Combine(resource, "wwwroot", "categoryimage", imageName);

                using (var stream = new FileStream(saveLocation, FileMode.Create))
                {
                    await insertVM.CategoryPhotoPath.CopyToAsync(stream);
                }

                // Dosya adını ImagePath alanına atayın
                category.CategoryPhotoPath = imageName;
            }

            await _categoryManager.AddAsync(category);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var category = await _categoryManager.FindAsync(id);
            if (category == null)
            {
                return NotFound();
            }

            var viewModel = _mapper.Map<CategoryUpdateVM>(category);
            ViewBag.pCategories = await _parentCategoryManager.GetAllAsync(null);
            return View(viewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Update(CategoryUpdateVM categoryUpdateVM, int id)
        {
            if (id != categoryUpdateVM.Id)
            {
                return BadRequest();
            }

            var validationResult = await _validator.ValidateAsync(categoryUpdateVM);
            if (!validationResult.IsValid)
            {
                foreach (var error in validationResult.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }
                return View(categoryUpdateVM);
            }

            var category = await _categoryManager.FindAsync(id);
            if (category == null)
            {
                return NotFound();
            }


            var category2 = _mapper.Map<Category>(categoryUpdateVM);
            if (categoryUpdateVM.CategoryPhotoUpdate != null)
            {
                var resource = Directory.GetCurrentDirectory();
                var extension = Path.GetExtension(categoryUpdateVM.CategoryPhotoUpdate.FileName);
                var imagename = Guid.NewGuid() + extension;
                var savelocation = Path.Combine(resource, "wwwroot", "productimage", imagename);
                using (var stream = new FileStream(savelocation, FileMode.Create))
                {
                    await categoryUpdateVM.CategoryPhotoUpdate.CopyToAsync(stream);
                }
                category2.CategoryPhotoPath = imagename;
            }
            else
            {
                // Eğer yeni bir resim seçilmemişse, mevcut resmi kullan
                category2.CategoryPhotoPath = categoryUpdateVM.CategoryPhotoPath;
            }
            await _categoryManager.UpdateAsync(category2);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var category = await _categoryManager.FindAsync(id);
            if (category != null)
            {
                await _categoryManager.DeleteAsync(category);
            }
            return RedirectToAction("Index");
        }
    }

}

