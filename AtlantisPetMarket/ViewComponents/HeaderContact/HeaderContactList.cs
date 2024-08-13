using BusinessLayer.Abstract;
using EntityLayer.DbContexts;
using EntityLayer.Models.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace AtlantisPetMarket.ViewComponents.HeaderContact
{
    public class HeaderContactList : ViewComponent
    {
        private readonly IContactManager<AppDbContext, Contact, int> _contactManager;

        public HeaderContactList(IContactManager<AppDbContext, Contact, int> contactManager)
        {
            _contactManager = contactManager;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _contactManager.GetAllAsync(null);
            return View(values);

        }

    }
}
