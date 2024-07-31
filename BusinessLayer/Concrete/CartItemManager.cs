using BusinessLayer.Abstract;
using EntityLayer.Models.Concrete;
using Microsoft.EntityFrameworkCore;

namespace BusinessLayer.Concrete
{
    public class CartItemManager<TContext, T, TId> : GenericManager<TContext, T, TId>, ICartItemManager<TContext, T, TId>
        where TContext : DbContext, new()
        where T : CartItem
    {
        public CartItemManager(TContext context) : base(context)
        {
        }
    }
}
