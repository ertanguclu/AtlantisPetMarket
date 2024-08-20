using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using EntityLayer.DbContexts;
using EntityLayer.Models.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace AtlantisPetMarket.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderManager<AppDbContext, Order, int> _orderManager;
        private readonly IOrderItemManager<AppDbContext, OrderItem, int> _orderItemManager;
        public OrderController(IOrderManager<AppDbContext, Order, int> orderManager, IOrderItemManager<AppDbContext, OrderItem, int> orderItemManager)
        {
            _orderManager = orderManager;
            _orderItemManager = orderItemManager;
        }
        public async Task<IActionResult> Index(int id)
        {
            var order = await _orderManager.FindAsync(id);
            if (order == null)
            {
                return NotFound();
            }

            return View();
        }
    }
}
