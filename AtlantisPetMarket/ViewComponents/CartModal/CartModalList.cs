using AutoMapper;
using BusinessLayer.Abstract;
using BusinessLayer.Models.CartItemVM;
using BusinessLayer.Models.CartViewModel;
using EntityLayer.DbContexts;
using EntityLayer.Models.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace AtlantisPetMarket.ViewComponents.CartModalList
{
    public class CartModalList : ViewComponent
    {
        private readonly ICartManager<AppDbContext, Cart, int> _cartManager;
        private readonly ICartItemManager<AppDbContext, CartItem, int> _cartItemManager;
        private readonly IMapper _mapper;

        public CartModalList(ICartManager<AppDbContext, Cart, int> cartManager, ICartItemManager<AppDbContext, CartItem, int> cartItemManager, IMapper mapper)
        {
            _cartManager = cartManager;
            _cartItemManager = cartItemManager;
            _mapper = mapper;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            // Cookie'den gelen CartId'yi al
            var cartIdFromCookie = HttpContext.Request.Cookies["CartId"];
            ProductCartVM cartVM = new ProductCartVM();

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
                    cartVM = _mapper.Map<ProductCartVM>(cart);
                    cartVM.CartItems = cartItemVMs;
                }
            }

            // Eğer sepet yoksa boş bir model oluştur
            if (cartVM.CartItems == null)
            {
                cartVM.CartItems = new List<CartItemViewModel>();
            }

            return View(cartVM); // Default view'ı döndür
        }
    }
}
