using EntityLayer.Models.Concrete;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BusinessLayer.Abstract
{
    public interface IProductManager<TContext, T, TId> : IGenericManager<TContext, T, TId>
         where TContext : DbContext, new()
        where T : Product
    {
        Task<IEnumerable<T>> GetProductsByCategoryAsync(Expression<Func<T, bool>>? filter, params Expression<Func<T, object>>[] include);
    }
}
