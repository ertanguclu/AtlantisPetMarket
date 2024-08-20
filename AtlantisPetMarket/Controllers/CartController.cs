using AutoMapper;
using BusinessLayer.Abstract;
using BusinessLayer.Models.CartItemVM;
using BusinessLayer.Models.CartViewModel;
using EntityLayer.DbContexts;
using EntityLayer.Models.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using System.Security.Claims;

namespace AtlantisPetMarket.Controllers
{
    public class CartController : Controller
    {
        private readonly ICartManager<AppDbContext, Cart, int> _cartManager;
        private readonly ICartItemManager<AppDbContext, CartItem, int> _cartItemManager;
        private readonly IProductManager<AppDbContext, Product, int> _productManager;
        private readonly IMapper _mapper;
        //private readonly IValidator<CartVM> _validator;

        public CartController(ICartManager<AppDbContext, Cart, int> cartManager, ICartItemManager<AppDbContext, CartItem, int> cartItemManager, IMapper mapper, IProductManager<AppDbContext, Product, int> productManager)
        {
            _cartManager = cartManager;
            _cartItemManager = cartItemManager;
            _productManager = productManager;
            _mapper = mapper;
            //_validator = validator;
        }

        public async Task<IActionResult> Index(int id)
        {
            var cartIdFromCookie = Request.Cookies["CartId"];

            if (!string.IsNullOrEmpty(cartIdFromCookie) && int.TryParse(cartIdFromCookie, out var cartIdFromCookieInt))
            {
                var cart = await _cartManager.FindAsync(cartIdFromCookieInt);

                if (cart != null)
                {
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

            return RedirectToAction("EmptyCart");
        }
        [HttpGet]
        public async Task<JsonResult> Search(string searchQuery)
        {
            var lowerQuery = searchQuery.ToLower();
            var filteredProducts = await _productManager.GetProductsByCategoryAsync(c => c.ProductName.ToLower().Contains(lowerQuery));

            var productVM = _mapper.Map<IEnumerable<ProductCartVM>>(filteredProducts);

            return Json(productVM);
        }
        public async Task<IActionResult> Details(int id)
        {
            var productDetails = await _productManager.FindAsync(id);
            var productVM = _mapper.Map<ProductCartVM>(productDetails);
            if (productVM == null)
            {
                return NotFound();
            }
            return View(productVM);
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
            // Oturum ID'sini al veya oluştur
            string sessionId = HttpContext.Request.Cookies["SessionId"] ?? Guid.NewGuid().ToString();
            HttpContext.Response.Cookies.Append("SessionId", sessionId, new CookieOptions
            {
                Expires = DateTimeOffset.UtcNow.AddHours(1),
                HttpOnly = true,
                Secure = true
            });

            int? userId = User.Identity.IsAuthenticated ? Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier)) : (int?)null;
            // Nullable integer

            Cart existingCart;

            if (userId.HasValue)
            {
                // Kullanıcı oturum açmış
                existingCart = await _cartManager.GetCartByUserIdAsync(userId.Value);
            }
            else
            {
                // Kullanıcı oturum açmamış
                existingCart = await _cartManager.GetCartBySessionIdAsync(sessionId);
            }

            if (existingCart == null)
            {
                productCartVM.SessionId = sessionId;
                productCartVM.UserId = userId; // Nullable olduğu için sorun olmayacak
                var newCart = _mapper.Map<Cart>(productCartVM);

                await _cartManager.AddAsync(newCart);
                productCartVM.CartId = newCart.Id;
            }
            else
            {
                productCartVM.CartId = existingCart.Id;
            }

            var existingCartItem = await _cartItemManager.GetByConditionAsync(
                x => x.CartId == productCartVM.CartId && x.ProductId == productCartVM.ProductId);

            if (existingCartItem != null)
            {
                existingCartItem.Quantity += productCartVM.Quantity;
                await _cartItemManager.UpdateAsync(existingCartItem);
            }
            else
            {
                var cartItem = _mapper.Map<CartItem>(productCartVM);
                await _cartItemManager.AddAsync(cartItem);
            }

            Response.Cookies.Append("CartId", productCartVM.CartId.ToString(), new CookieOptions
            {
                Expires = DateTimeOffset.UtcNow.AddHours(1),
                HttpOnly = true,
                Secure = true
            });

            return RedirectToAction("Index", "Home");
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


        [HttpPost]
        public async Task<IActionResult> IncreaseQuantity(int cartItemId)
        {
            var cartItem = await _cartItemManager.FindAsync(cartItemId);
            if (cartItem == null)
            {
                return NotFound();
            }

            cartItem.Quantity += 1;
            await _cartItemManager.UpdateAsync(cartItem);

            return RedirectToAction("Index", new { id = cartItem.CartId });
        }

        [HttpPost]
        public async Task<IActionResult> DecreaseQuantity(int cartItemId)
        {
            var cartItem = await _cartItemManager.FindAsync(cartItemId);
            if (cartItem == null)
            {
                return NotFound();
            }
            if (cartItem.Quantity > 1)
            {
                cartItem.Quantity -= 1;
                await _cartItemManager.UpdateAsync(cartItem);
            }
            else
            {

                await _cartItemManager.DeleteAsync(cartItem);
            }

            return RedirectToAction("Index", new { id = cartItem.CartId });
        }





        public async Task<IActionResult> EmptyCart()
        {

            return View();
        }


    }
}
