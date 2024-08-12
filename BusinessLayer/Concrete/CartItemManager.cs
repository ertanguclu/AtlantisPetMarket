using BusinessLayer.Abstract;
using EntityLayer.Models.Concrete;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class CartItemManager<TContext, T, TId> : GenericManager<TContext, T, TId>, ICartItemManager<TContext, T, TId>
        where TContext : DbContext, new()
        where T : CartItem
    {
        private readonly TContext _context;

        public CartItemManager(TContext context) : base(context)
        {
            _context = context;
        }

        public async Task<CartItem?> GetByConditionAsync(Expression<Func<CartItem, bool>> predicate)
        {
            return await _context.Set<CartItem>()
                .FirstOrDefaultAsync(predicate);
        }
    }
}
