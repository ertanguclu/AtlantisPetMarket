using AtlantisPetMarket.Models.CartItemVM;
using AtlantisPetMarket.Models.CartVM;
using AtlantisPetMarket.Models.CategoryVM;
using AtlantisPetMarket.Models.ProductVM;
using AutoMapper;
using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
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
        private readonly IValidator<CartInsertVM> _validator;
        public CartController(ICartManager<AppDbContext, Cart, int> cartManager, ICartItemManager<AppDbContext, CartItem, int> cartItemManager, IMapper mapper, IValidator<CartInsertVM> validator)
        {
            _cartManager = cartManager;
            _cartItemManager = cartItemManager;
            _mapper = mapper;
            _validator = validator;
        }
        //public async Task<ActionResult<IEnumerable<Cart>>> Index(int id)
        //{
        //    var carts = await _cartManager.GetAllIncludeAsync(x => x.Id == id, x => x.CreateDateTime, x => x.UserId);
        //    return View(carts);
        //}


        //public async Task<IActionResult> Index(int id)
        //{
        //    // Sepeti ve ilişkili CartItem'ları getir
        //    var cart = await _cartManager.FindAsync(id);
        //    if (cart == null)
        //    {
        //        return NotFound(); // Sepet bulunamazsa hata döndür
        //    }

        //    var cartItems = await _cartItemManager.GetAllIncludeAsync(
        //        x => x.CartId == id,
        //        x => x.Product // Sadece navigation property'e include
        //    );

        //    // Sepet ve CartItem'ları ViewModel'e dönüştür
        //    var cartVM = _mapper.Map<CartVM>(cart);
        //    cartVM.CartItems = _mapper.Map<IEnumerable<CartItemVM>>(cartItems);

        //    // View'e gönder
        //    return View(cartVM);
        //}

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            CartInsertVM cartInsertVM = new CartInsertVM();
            return View(cartInsertVM);

        }
        [HttpPost]
        public async Task<IActionResult> Create(CartInsertVM cartInsertVM)
        {
            if (!ModelState.IsValid)
            {
                // Model geçerli değilse hata mesajlarını göster
                return View(cartInsertVM);
            }

            // Model doğrulaması
            var validationResult = _validator.Validate(cartInsertVM);
            if (!validationResult.IsValid)
            {
                foreach (var error in validationResult.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }

                // Kategorileri veya diğer gerekli verileri yeniden gönder
                return View(cartInsertVM);
            }

            // AutoMapper ile CartInsertVM'yi Cart entity'sine dönüştür
            var cart = _mapper.Map<Cart>(cartInsertVM);

            // Sepeti veritabanına ekle
            await _cartManager.AddAsync(cart);

            // Başarıyla ekledikten sonra kullanıcıyı uygun bir sayfaya yönlendir
            return RedirectToAction("Index");
        }


    }
}
