using BusinessLayer.Models.CartItemVM;
using BusinessLayer.Models.CartViewModel;
using BusinessLayer.Models.ProductVM;
using AutoMapper;
using BusinessLayer.Abstract;
using EntityLayer.DbContexts;
using EntityLayer.Models.Concrete;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace AtlantisPetMarket.Controllers
{
    public class CartController : Controller
    {
        private readonly ICartManager<AppDbContext, Cart, int> _cartManager;
        private readonly ICartItemManager<AppDbContext, CartItem, int> _cartItemManager;
        private readonly IMapper _mapper;
        //private readonly IValidator<CartVM> _validator;

        public CartController(ICartManager<AppDbContext, Cart, int> cartManager, ICartItemManager<AppDbContext, CartItem, int> cartItemManager, IMapper mapper)
        {
            _cartManager = cartManager;
            _cartItemManager = cartItemManager;
            _mapper = mapper;
            //_validator = validator;
        }

        public async Task<IActionResult> Index(int id)
        {
            // Cookie'den gelen CartId'yi al
            var cartIdFromCookie = Request.Cookies["CartId"];

            if (!string.IsNullOrEmpty(cartIdFromCookie) && int.TryParse(cartIdFromCookie, out var cartIdFromCookieInt))
            {
                // Cookie'den gelen CartId ile sepeti al
                var cart = await _cartManager.FindAsync(cartIdFromCookieInt);

                if (cart != null)
                {
                    // Sepet var, işleme devam et
                    var cartItems = await _cartItemManager.GetAllIncludeAsync(
                        x => x.CartId == cartIdFromCookieInt,
                        x => x.Product
                    );

                    var cartItemVMs = _mapper.Map<List<CartItemViewModel>>(cartItems);
                    var cartVM = _mapper.Map<ProductCartVM>(cart);
                    cartVM.CartItems = cartItemVMs;

                    return View(cartVM);
                }
            }

            // Cookie'den gelen CartId geçerli değilse veya sepet bulunamadıysa
            return RedirectToAction("EmptyCart");
        }


        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ProductCartVM productCartVM = new ProductCartVM();
            return View(productCartVM);
        }


        [HttpPost]
        public async Task<IActionResult> Create(ProductCartVM productCartVM)
        {
            var userId = User.Identity.IsAuthenticated ? Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier)) : -1;

            var existingCart = await _cartManager.GetCartByUserIdAsync(userId);

            if (existingCart == null)
            {
                var newCart = _mapper.Map<Cart>(productCartVM);
                newCart.UserId = userId;

                await _cartManager.AddAsync(newCart);
                productCartVM.CartId = newCart.Id;
            }
            else
            {
                productCartVM.CartId = existingCart.Id;
            }

            var cartItem = _mapper.Map<CartItem>(productCartVM);

            await _cartItemManager.AddAsync(cartItem);
            Response.Cookies.Append("CartId", productCartVM.CartId.ToString(), new CookieOptions
            {
                Expires = DateTimeOffset.UtcNow.AddHours(1), // Cookie'nin geçerlilik süresi
                HttpOnly = true // Cookie'ye sadece sunucu tarafından erişilebilir
            });

            return RedirectToAction("Index", new { id = productCartVM.CartId });
        }


        [HttpPost]
        public async Task<IActionResult> Delete(int cartItemId, int cartId)
        {
            var cartItem = await _cartItemManager.FindAsync(cartItemId);
            if (cartItem == null)
            {
                return NotFound();
            }

            await _cartItemManager.DeleteAsync(cartItem);

            var remainingItems = await _cartItemManager.GetAllIncludeAsync(x => x.CartId == cartId);
            if (!remainingItems.Any())
            {
                var cart = await _cartManager.FindAsync(cartId);
                if (cart != null)
                {
                    await _cartManager.DeleteAsync(cart);
                }
                Response.Cookies.Delete("CartId");
                return RedirectToAction("EmptyCart");
            }

            return RedirectToAction("Index", new { id = cartId });
        }

        public async Task<IActionResult> EmptyCart()
        {

            return View();
        }

    }
}
