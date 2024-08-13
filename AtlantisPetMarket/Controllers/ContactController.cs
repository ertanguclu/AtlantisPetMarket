using AutoMapper;
using BusinessLayer.Abstract;
using BusinessLayer.Models.ContactVM;
using EntityLayer.DbContexts;
using EntityLayer.Models.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace AtlantisPetMarket.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactManager<AppDbContext, Contact, int> _contactManager;
        private readonly IMapper _mapper;
        public ContactController(IContactManager<AppDbContext, Contact, int> contactManager, IMapper mapper)
        {
            _contactManager = contactManager;
            _mapper = mapper;
        }
        public async Task<ActionResult<IEnumerable<Contact>>> Index()
        {
            var contacts = await _contactManager.GetAllAsync(null);
            var vmContacts = _mapper.Map<IEnumerable<ContactListVM>>(contacts);
            return View(vmContacts);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ContactInsertVM contactVM = new ContactInsertVM();

            return View(contactVM);

        }
        [HttpPost]
        public async Task<IActionResult> Create(Contact contact)
        {

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
