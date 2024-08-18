using AutoMapper;
using BusinessLayer.Abstract;
using BusinessLayer.Models.SocialMediaVM;
using EntityLayer.DbContexts;
using EntityLayer.Models.Concrete;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace AtlantisPetMarket.Controllers
{
    public class SocialMediaController : Controller
    {
        private readonly ISocialMediaManager<AppDbContext, SocialMedia, int> _socialMediaManager;
        private readonly IValidator<SocialMediaInsertVM> _socialMediaInsertValidator;
        private readonly IValidator<SocialMediaUpdateVM> _socialMediaUpdateValidator;
        private readonly IMapper _mapper;
        public SocialMediaController(ISocialMediaManager<AppDbContext, SocialMedia, int> socialMediaManager, IMapper mapper, IValidator<SocialMediaUpdateVM> socialMediaUpdateValidator, IValidator<SocialMediaInsertVM> socialMediaInsertValidator)
        {
            _socialMediaManager = socialMediaManager;
            _mapper = mapper;
            _socialMediaUpdateValidator = socialMediaUpdateValidator;
            _socialMediaInsertValidator = socialMediaInsertValidator;
        }
        public async Task<ActionResult> Index()
        {
            var socialMedias = await _socialMediaManager.GetAllAsync(null);
            var socialMediaListVM = _mapper.Map<IEnumerable<SocialMediaListVM>>(socialMedias);
            return View(socialMediaListVM);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(SocialMediaInsertVM socialMediaInsertVM)
        {
            var result = await _socialMediaInsertValidator.ValidateAsync(socialMediaInsertVM);
            if (!result.IsValid)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }
                return View(socialMediaInsertVM);

            }
            var socialMedia = _mapper.Map<SocialMedia>(socialMediaInsertVM);
            await _socialMediaManager.AddAsync(socialMedia);
            return RedirectToAction("Index");

        }
        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var socialMedia = await _socialMediaManager.FindAsync(id);
            var socialMediaUpdateVM = _mapper.Map<SocialMediaUpdateVM>(socialMedia);
            //ViewBag.sIcon = socialMedia.Icon;
            return View(socialMediaUpdateVM);
        }
        [HttpPost]
        public async Task<IActionResult> Update(SocialMediaUpdateVM socialMediaUpdateVM)
        {

            var result = await _socialMediaUpdateValidator.ValidateAsync(socialMediaUpdateVM);
            if (!result.IsValid)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }
                return View(socialMediaUpdateVM);

            }
            var socialMedia = _mapper.Map<SocialMedia>(socialMediaUpdateVM);
            await _socialMediaManager.UpdateAsync(socialMedia);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var socialMedia = await _socialMediaManager.FindAsync(id);
            await _socialMediaManager.DeleteAsync(socialMedia);
            return RedirectToAction("Index");
        }

    }
}
