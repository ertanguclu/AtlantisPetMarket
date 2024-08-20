using BusinessLayer.Abstract;
using EntityLayer.Models.Concrete;
using Microsoft.EntityFrameworkCore;

namespace BusinessLayer.Concrete
{
    public class OrderManager<TContext, T, TId> : GenericManager<TContext, T, TId>, IOrderManager<TContext, T, TId>
        where TContext : DbContext, new()
        where T : Order
    {
        public OrderManager(TContext context) : base(context)
        {
        }
    }
}
