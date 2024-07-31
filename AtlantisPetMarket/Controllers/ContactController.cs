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
