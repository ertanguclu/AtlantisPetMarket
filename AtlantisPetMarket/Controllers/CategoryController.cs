using AutoMapper;
using BusinessLayer.Abstract;
using BusinessLayer.Models.CategoryVM;
using EntityLayer.DbContexts;
using EntityLayer.Models.Concrete;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace AtlantisPetMarket.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IProductManager<AppDbContext, Product, int> _productManager;
        private readonly ICategoryManager<AppDbContext, Category, int> _categoryManager;
        private readonly IParentCategoryManager<AppDbContext, ParentCategory, int> _parentCategoryManager;
        private readonly IMapper _mapper;
        private readonly IValidator<CategoryInsertVM> _insertValidator;
        private readonly IValidator<CategoryUpdateVM> _updateValidator;
        public CategoryController(ICategoryManager<AppDbContext, Category, int> categoryManager,
            IProductManager<AppDbContext, Product, int> productManager, IParentCategoryManager<AppDbContext, ParentCategory, int> parentCategoryManager, IMapper mapper, IValidator<CategoryInsertVM> insertValidator, IValidator<CategoryUpdateVM> updateValidator)
        {
            _productManager = productManager;
            _categoryManager = categoryManager;
            _mapper = mapper;
            _insertValidator = insertValidator;
            _updateValidator = updateValidator;
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

            var result = await _insertValidator.ValidateAsync(insertVM);
            if (!result.IsValid)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }
                return View(insertVM);

            }
            var category = _mapper.Map<Category>(insertVM);

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


            var result = await _updateValidator.ValidateAsync(categoryUpdateVM);
            if (!result.IsValid)
            {
                foreach (var error in result.Errors)
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

            _mapper.Map(categoryUpdateVM, category);
            await _categoryManager.UpdateAsync(category);
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

