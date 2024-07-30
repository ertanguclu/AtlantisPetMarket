using BusinessLayer.Abstract;
using EntityLayer.Models.Concrete;
using Microsoft.EntityFrameworkCore;

namespace BusinessLayer.Concrete
{
    public class CartManager<TContext, T, TId> : GenericManager<TContext, T, TId>, ICartManager<TContext, T, TId>
        where TContext : DbContext, new()
        where T : Cart
    {
        public CartManager(TContext context) : base(context)
        {
        }
    }
}
