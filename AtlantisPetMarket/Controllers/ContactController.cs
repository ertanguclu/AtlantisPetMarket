using BusinessLayer.Abstract;
using EntityLayer.DbContexts;
using EntityLayer.Models.Concrete;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace AtlantisPetMarket.Controllers
{
    public class ContactController : Controller
    {
        private readonly IGenericManager<AppDbContext, Contact, int> _contactManager;
        private readonly IValidator<Contact> _validator;
        public ContactController(IGenericManager<AppDbContext, Contact, int> contactManager, IValidator<Contact> validator)
        {
            _contactManager = contactManager;
            _validator = validator;
        }
        public async Task<ActionResult<IEnumerable<Contact>>> Index(int id)
        {
            var contacts = await _contactManager.GetAllAsync(null);
            return View(contacts);
        }
    }
}
