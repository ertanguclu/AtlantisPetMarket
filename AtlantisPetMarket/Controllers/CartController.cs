using AtlantisPetMarket.Models.CartItemVM;
using AtlantisPetMarket.Models.CartViewModel;
using AutoMapper;
using BusinessLayer.Abstract;
using EntityLayer.DbContexts;
using EntityLayer.Models.Concrete;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace AtlantisPetMarket.Controllers
{
    public class CartController : Controller
    {
        private readonly ICartManager<AppDbContext, Cart, int> _cartManager;
        private readonly ICartItemManager<AppDbContext, CartItem, int> _cartItemManager;
        private readonly IMapper _mapper;
        private readonly IValidator<CartVM> _validator;

        public CartController(ICartManager<AppDbContext, Cart, int> cartManager, ICartItemManager<AppDbContext, CartItem, int> cartItemManager, IMapper mapper, IValidator<CartVM> validator)
        {
            _cartManager = cartManager;
            _cartItemManager = cartItemManager;
            _mapper = mapper;
            _validator = validator;
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

            var cartVM = _mapper.Map<CartVM>(cart);
            cartVM.CartItems = _mapper.Map<IEnumerable<CartItemViewModel>>(cartItems);

            return View(cartVM);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            CartVM cartVM = new CartVM();
            return View(cartVM);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CartVM CartVM)
        {
            // ModelState validasyonunu kontrol et
            if (!ModelState.IsValid)
            {
                return View(CartVM);
            }

            // FluentValidation ile ek doğrulama yap
            var validationResult = _validator.Validate(CartVM);
            if (!validationResult.IsValid)
            {
                foreach (var error in validationResult.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }
                return View(CartVM);
            }

            var cart = _mapper.Map<Cart>(CartVM);
            await _cartManager.AddAsync(cart);

            return RedirectToAction("Index");
        }
    }
}
