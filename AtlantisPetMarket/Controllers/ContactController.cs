using BusinessLayer.Abstract;
using EntityLayer.DbContexts;
using EntityLayer.Models.Concrete;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace AtlantisPetMarket.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactManager<AppDbContext, Contact, int> _contactManager;
        private readonly IValidator<Contact> _validator;
        public ContactController(IContactManager<AppDbContext, Contact, int> contactManager, IValidator<Contact> validator)
        {
            _contactManager = contactManager;
            _validator = validator;
        }
        public async Task<ActionResult<IEnumerable<Contact>>> Index(int id)
        {
            var contacts = await _contactManager.GetAllAsync(null);
            return View(contacts);
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
