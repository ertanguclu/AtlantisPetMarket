using BusinessLayer.Abstract;
using EntityLayer.DbContexts;
using EntityLayer.Models.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace AtlantisPetMarket.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactManager<AppDbContext, Contact, int> _contactManager;
        public ContactController(IContactManager<AppDbContext, Contact, int> contactManager)
        {
            _contactManager = contactManager;

        }
        public async Task<ActionResult<IEnumerable<Contact>>> Index()
        {
            var contacts = await _contactManager.GetAllAsync(null);
            return View(contacts);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            Contact contact = new Contact();

            return View(contact);

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
            return View(contact);
        }
        [HttpPost]
        public async Task<IActionResult> Update(Contact contact)
        {
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
