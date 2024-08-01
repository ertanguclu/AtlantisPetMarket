using BusinessLayer.Abstract;
using EntityLayer.DbContexts;
using EntityLayer.Models.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace AtlantisPetMarket.Controllers
{
    public class CartController : Controller
    {
        private readonly ICartManager<AppDbContext, Cart, int> _cartManager;
        private readonly ICartItemManager<AppDbContext, CartItem, int> _cartItemManager;
        public CartController(ICartManager<AppDbContext, Cart, int> cartManager, ICartItemManager<AppDbContext, CartItem, int> cartItemManager)
        {
            _cartManager = cartManager;
            _cartItemManager = cartItemManager;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
