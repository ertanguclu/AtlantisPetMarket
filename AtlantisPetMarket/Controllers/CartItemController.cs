using AtlantisPetMarket.Models.CartItemVM;
using AutoMapper;
using BusinessLayer.Abstract;
using EntityLayer.DbContexts;
using EntityLayer.Models.Concrete;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AtlantisPetMarket.Controllers
{
    public class CartItemController : Controller
    {
        private readonly ICartItemManager<AppDbContext, CartItem, int> _cartItemManager;
        private readonly IMapper _mapper;
        private readonly IValidator<CartItemViewModel> _validator;

        public CartItemController(ICartItemManager<AppDbContext, CartItem, int> cartItemManager, IMapper mapper, IValidator<CartItemViewModel> validator)
        {
            _cartItemManager = cartItemManager;
            _mapper = mapper;
            _validator = validator;
        }

        public async Task<ActionResult<IEnumerable<CartItemViewModel>>> Index(int id)
        {
            var cartItems = await _cartItemManager.GetAllIncludeAsync(
                x => x.CartId == id,
                x => x.Product // Burada Product navigasyon özelliğini belirtmelisiniz
            );

            var cartItemVMs = _mapper.Map<IEnumerable<CartItemViewModel>>(cartItems);

            return View(cartItemVMs);
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrUpdate(CartItemViewModel cartItemVM)
        {
            if (!ModelState.IsValid)
            {
                return View(cartItemVM);
            }

            var existingCartItem = await _cartItemManager.GetByAsync(x => x.ProductId == cartItemVM.ProductId && x.CartId == cartItemVM.CartId);

            if (existingCartItem != null)
            {
                // Eğer aynı ürün zaten varsa, miktarı artır
                existingCartItem.Quantity += cartItemVM.Quantity;
                await _cartItemManager.UpdateAsync(existingCartItem);
            }
            else
            {
                // Yeni bir ürün ekliyorsak, normal ekleme işlemi yap
                var cartItem = _mapper.Map<CartItem>(cartItemVM);
                await _cartItemManager.AddAsync(cartItem);
            }

            return RedirectToAction("Index", new { id = cartItemVM.CartId });
        }

        private async Task<bool> CartItemExists(int id)
        {
            return await _cartItemManager.FindAsync(id) != null;
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var cartItem = await _cartItemManager.FindAsync(id);

            if (cartItem == null)
            {
                return NotFound();
            }

            var cartItemVM = _mapper.Map<CartItemViewModel>(cartItem);
            return View(cartItemVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, CartItemViewModel cartItemVM)
        {
            if (id != cartItemVM.Id)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return View(cartItemVM);
            }

            var cartItem = _mapper.Map<CartItem>(cartItemVM);

            try
            {
                await _cartItemManager.UpdateAsync(cartItem);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await CartItemExists(cartItem.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToAction(nameof(Index), new { id = cartItem.CartId });
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var cartItem = await _cartItemManager.FindAsync(id);

            if (cartItem == null)
            {
                return NotFound();
            }

            var cartItemVM = _mapper.Map<CartItemViewModel>(cartItem);
            return View(cartItemVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cartItem = await _cartItemManager.FindAsync(id);

            if (cartItem != null)
            {
                await _cartItemManager.DeleteAsync(cartItem);
            }

            return RedirectToAction(nameof(Index), new { id = cartItem.CartId });
        }
    }
}
