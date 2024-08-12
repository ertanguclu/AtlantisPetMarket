using BusinessLayer.Abstract;
using EntityLayer.Models.Concrete;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Linq;

namespace BusinessLayer.Concrete
{
    public class CartManager<TContext, T, TId> : GenericManager<TContext, T, TId>, ICartManager<TContext, T, TId>
        where TContext : DbContext, new()
        where T : Cart
    {
        private readonly TContext _context;

        public CartManager(TContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Cart?> GetCartByUserIdAsync(int userId)
        {
            return await _context.Set<Cart>()
                .FirstOrDefaultAsync(c => c.UserId == userId);
        }

     
    }
}
