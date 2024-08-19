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
        public async Task<JsonResult> Search(string searchQuery)
        {
            var lowerQuery = searchQuery.ToLower();
            var filteredProducts = await _productManager.GetAllIncludeAsync(c => c.ProductName.ToLower().Contains(lowerQuery));


            // Eğer ürünler doğru dönmüyorsa, `filteredProducts` üzerinde debug yaparak ne döndüğünü kontrol edin.
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

        //public async Task<IActionResult> CartModalPartial()
        //{
        //    // Cookie'den gelen CartId'yi al
        //    var cartIdFromCookie = Request.Cookies["CartId"];

        //    ProductCartVM cartVM = new ProductCartVM();

        //    if (!string.IsNullOrEmpty(cartIdFromCookie) && int.TryParse(cartIdFromCookie, out var cartIdFromCookieInt))
        //    {
        //        // Cookie'den gelen CartId ile sepeti al
        //        var cart = await _cartManager.FindAsync(cartIdFromCookieInt);

        //        if (cart != null)
        //        {
        //            // Sepet var, işleme devam et
        //            var cartItems = await _cartItemManager.GetAllIncludeAsync(
        //                x => x.CartId == cartIdFromCookieInt,
        //                x => x.Product
        //            );

        //            var cartItemVMs = _mapper.Map<List<CartItemViewModel>>(cartItems);
        //            cartVM = _mapper.Map<ProductCartVM>(cart);
        //            cartVM.CartItems = cartItemVMs;
        //        }
        //    }

        //    // Eğer sepet yoksa boş bir model oluştur
        //    if (cartVM.CartItems == null)
        //    {
        //        cartVM.CartItems = new List<CartItemViewModel>();
        //    }

        //    return PartialView("HomeLayoutPartial/CartModalPartial", cartVM); // Partial view'ı döndür
        //}




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

            // Sepeti kontrol et
            var existingCart = await _cartManager.GetCartByUserIdAsync(userId);

            if (existingCart == null)
            {
                // Yeni bir sepet oluştur
                var newCart = _mapper.Map<Cart>(productCartVM);
                newCart.UserId = userId;

                await _cartManager.AddAsync(newCart);
                productCartVM.CartId = newCart.Id;
            }
            else
            {
                productCartVM.CartId = existingCart.Id;
            }

            // Aynı ürünün sepette olup olmadığını kontrol et
            var existingCartItem = await _cartItemManager.GetByConditionAsync(
                x => x.CartId == productCartVM.CartId && x.ProductId == productCartVM.ProductId);

            if (existingCartItem != null)
            {
                // Ürün zaten sepette, miktarı artır
                existingCartItem.Quantity += productCartVM.Quantity;
                await _cartItemManager.UpdateAsync(existingCartItem);
            }
            else
            {
                // Ürün sepette değil, yeni bir CartItem ekle
                var cartItem = _mapper.Map<CartItem>(productCartVM);
                await _cartItemManager.AddAsync(cartItem);
            }

            // Cookie işlemleri
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
