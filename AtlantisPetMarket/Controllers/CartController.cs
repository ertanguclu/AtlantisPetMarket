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
            var cart = await _cartManager.FindAsync(id);
            if (cart == null)
            {
                return NotFound();
            }

            var cartItems = await _cartItemManager.GetAllIncludeAsync(
                x => x.CartId == id,
                x => x.Product
            );

            var cartItemVMs = new List<CartItemViewModel>();
            foreach (var item in cartItems)
            {
                var cartItemVM = new CartItemViewModel
                {
                    ProductId = item.Product.Id,
                    ProductName = item.Product.ProductName,
                    Quantity = item.Quantity,
                    Price = item.Product.Price,
                    CartId = item.CartId,  
                    Id = item.Id           
                };
                cartItemVMs.Add(cartItemVM);
            }

            var cartVM = _mapper.Map<ProductCartVM>(cart);
            cartVM.CartItems = cartItemVMs; 

            return View(cartVM);
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
                var newCart = new Cart
                {
                    UserId = userId 
                };

                await _cartManager.AddAsync(newCart);
                productCartVM.CartId = newCart.Id;
            }
            else
            {
                productCartVM.CartId = existingCart.Id;
            }

            var cartItem = new CartItem
            {
                CartId = productCartVM.CartId,
                ProductId = productCartVM.ProductId,
                Quantity = productCartVM.Quantity
            };

            await _cartItemManager.AddAsync(cartItem);

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
                return RedirectToAction("EmptyCart");
            }

            return RedirectToAction("Index", new { id = cartId });
        }

        public async Task <IActionResult> EmptyCart()
        {
            
            return View();
        }

    }
}
