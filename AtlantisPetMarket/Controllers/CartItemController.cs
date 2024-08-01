using AtlantisPetMarket.Models.CartItemVM;
using AutoMapper;
using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
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
        private readonly IValidator<CartItemVM> _validator;

        public CartItemController(ICartItemManager<AppDbContext, CartItem, int> cartItemManager, IMapper mapper, IValidator<CartItemVM> validator)
        {
            _cartItemManager = cartItemManager;
            _mapper = mapper;
            _validator = validator;
        }

        public async Task<ActionResult<IEnumerable<CartItemVM>>> Index(int id)
        {
            var cartItems = await _cartItemManager.GetAllIncludeAsync(
                x => x.Id == id,
                x => x.ProductId,
                x => x.Quantity,
                x => x.CreateDate
            );

            var cartItemVMs = _mapper.Map<IEnumerable<CartItemVM>>(cartItems);

            return View(cartItemVMs);
        }


        [HttpPost]
        public async Task<IActionResult> Create(CartItemVM cartItemVM)
        {
            if (!ModelState.IsValid)
            {
                return View(cartItemVM);
            }
            var cartItem = _mapper.Map<CartItem>(cartItemVM);
            await _cartItemManager.AddAsync(cartItem);

            // Başarıyla ekledikten sonra kullanıcıyı uygun bir sayfaya yönlendir
            return RedirectToAction("Index", new { cartId = cartItem.CartId });
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

            var cartItemVM = _mapper.Map<CartItemVM>(cartItem);
            return View(cartItemVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, CartItemVM cartItemVM)
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

            return RedirectToAction(nameof(Index), new { cartId = cartItem.CartId });
        }



        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var cartItem = await _cartItemManager.FindAsync(id);

            if (cartItem == null)
            {
                return NotFound();
            }

            var cartItemVM = _mapper.Map<CartItemVM>(cartItem);
            return View(cartItemVM);
        }
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cartItem = await _cartItemManager.FindAsync(id);

            if (cartItem != null)
            {
                await _cartItemManager.DeleteAsync(cartItem);
            }

            return RedirectToAction(nameof(Index), new { cartId = cartItem.CartId });
        }
    }
}