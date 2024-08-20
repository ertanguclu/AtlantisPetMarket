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
            var cartIdFromCookie = HttpContext.Request.Cookies["CartId"];
            ProductCartVM cartVM = new ProductCartVM();

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
                    cartVM = _mapper.Map<ProductCartVM>(cart);
                    cartVM.CartItems = cartItemVMs;
                }
            }

            if (cartVM.CartItems == null)
            {
                cartVM.CartItems = new List<CartItemViewModel>();
            }

            return View(cartVM); 
        }
    }
}
