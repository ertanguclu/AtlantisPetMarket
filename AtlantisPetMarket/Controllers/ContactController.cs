using AutoMapper;
using BusinessLayer.Abstract;
using BusinessLayer.Models.ContactVM;
using EntityLayer.DbContexts;
using EntityLayer.Models.Concrete;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace AtlantisPetMarket.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactManager<AppDbContext, Contact, int> _contactManager;
        private readonly IMapper _mapper;
        private readonly IValidator<ContactInsertVM> _insertValidator;
        private readonly IValidator<ContactUpdateVM> _updateValidator;

        public ContactController(IContactManager<AppDbContext, Contact, int> contactManager, IMapper mapper, IValidator<ContactInsertVM> insertValidator, IValidator<ContactUpdateVM> updateValidator)
        {
            _contactManager = contactManager;
            _mapper = mapper;
            _insertValidator = insertValidator;
            _updateValidator = updateValidator;
        }
        public async Task<ActionResult> Index()
        {
            var contacts = await _contactManager.GetAllAsync(null);
            var vmContacts = _mapper.Map<IEnumerable<ContactListVM>>(contacts);
            return View(vmContacts);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(ContactInsertVM contactInsertVM)
        {
            var result = await _insertValidator.ValidateAsync(contactInsertVM);
            if (!result.IsValid)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }
                return View(contactInsertVM);
            }
            var contact = _mapper.Map<Contact>(contactInsertVM);
            await _contactManager.AddAsync(contact);
            return RedirectToAction("Index");

        }
        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var contact = await _contactManager.FindAsync(id);
            if (contact == null)
            {
                return NotFound();
            }
            var viewModel = _mapper.Map<ContactUpdateVM>(contact);
            return View(viewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Update(ContactUpdateVM contactUpdateVM)
        {
            var result = await _updateValidator.ValidateAsync(contactUpdateVM);
            if (!result.IsValid)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }
                return View(contactUpdateVM);
            }
            var contact = _mapper.Map<Contact>(contactUpdateVM);
            await _contactManager.UpdateAsync(contact);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var contact = await _contactManager.FindAsync(id);
            if (contact != null)
            {
                await _contactManager.DeleteAsync(contact);
            }
            return RedirectToAction("Index");
        }
    }
}
