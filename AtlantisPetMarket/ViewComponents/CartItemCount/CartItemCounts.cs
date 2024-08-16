using BusinessLayer.Abstract;
using EntityLayer.DbContexts;
using EntityLayer.Models.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AtlantisPetMarket.ViewComponents.CartItemCounts
{
    public class CartItemCounts : ViewComponent
    {
        private readonly ICartManager<AppDbContext, Cart, int> _cartManager;

        public CartItemCounts(ICartManager<AppDbContext, Cart, int> cartManager)
        {
            _cartManager = cartManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var cartIdFromCookie = HttpContext.Request.Cookies["CartId"];
            int cartItemCount = 0;

            if (!string.IsNullOrEmpty(cartIdFromCookie) && int.TryParse(cartIdFromCookie, out var cartIdFromCookieInt))
            {
                var cart = await _cartManager.FindAsync(cartIdFromCookieInt);

                if (cart != null)
                {
                    cartItemCount = cart.CartItems.Count;
                }
            }

            return View(cartItemCount);
        }
    }
}
