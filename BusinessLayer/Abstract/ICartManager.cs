using Microsoft.EntityFrameworkCore;

namespace BusinessLayer.Abstract
{
    public interface ICartManager<TContext, T, TId> : IGenericManager<TContext, T, TId>
        where TContext : DbContext, new()
        where T : Cart
    {
        Task<Cart?> GetCartByUserIdAsync(int userId);
        Task<Cart> GetCartBySessionIdAsync(string sessionId);
    }
}
