using BusinessLayer.Abstract;
using EntityLayer.DbContexts;
using EntityLayer.Models.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace YourNamespace.Controllers
{
    public class AddressController : Controller
    {
        private readonly IAddressManager<AppDbContext, Address, int> _addressManager;

        public AddressController(IAddressManager<AppDbContext, Address, int> addressManager)
        {
            _addressManager = addressManager;
        }

        public async Task<IActionResult> Index()
        {
            var addresses = await _addressManager.GetAllAsync(null); 
            return View(addresses);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Address address)
        {
            if (ModelState.IsValid)
            {
                await _addressManager.AddAsync(address);
                return RedirectToAction(nameof(Index));
            }
            return View(address);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var address = await _addressManager.FindAsync(id);
            if (address == null)
            {
                return NotFound();
            }
            return View(address);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Address address)
        {
            if (id != address.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _addressManager.UpdateAsync(address);
                return RedirectToAction(nameof(Index));
            }
            return View(address);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var address = await _addressManager.FindAsync(id);
            if (address == null)
            {
                return NotFound();
            }
            return View(address);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var address = await _addressManager.FindAsync(id);
            if (address != null)
            {
                await _addressManager.DeleteAsync(address);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
