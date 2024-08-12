using BusinessLayer.Abstract;
using EntityLayer.Models.Concrete;
using Microsoft.EntityFrameworkCore;

namespace BusinessLayer.Concrete
{
    public class OrderItemManager<TContext, T, TId> : GenericManager<TContext, T, TId>, IOrderItemManager<TContext, T, TId>
        where TContext : DbContext, new()
        where T : OrderItem
    {
        public OrderItemManager(TContext context) : base(context)
        {
        }
    }
}
