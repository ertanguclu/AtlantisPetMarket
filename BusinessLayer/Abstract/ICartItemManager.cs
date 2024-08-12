using EntityLayer.Models.Concrete;
using Microsoft.EntityFrameworkCore;

namespace BusinessLayer.Abstract
{
    public interface ICartItemManager<TContext, T, TId> : IGenericManager<TContext, T, TId>
        where TContext : DbContext, new()
        where T : CartItem
    {
    }
}
