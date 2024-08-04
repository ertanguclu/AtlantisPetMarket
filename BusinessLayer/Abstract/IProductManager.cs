using EntityLayer.Models.Concrete;
using Microsoft.EntityFrameworkCore;

namespace BusinessLayer.Abstract
{
    public interface IProductManager<TContext, T, TId> : IGenericManager<TContext, T, TId>
         where TContext : DbContext, new()
        where T : Product
    {
        Task<IEnumerable<T>> GetProductsByCategoryAsync(string categoryName);
    }
}
