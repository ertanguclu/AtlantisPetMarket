using BusinessLayer.Abstract;
using EntityLayer.Models.Concrete;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BusinessLayer.Concrete
{
    public class ProductManager<TContext, T, TId> : GenericManager<TContext, T, TId>, IProductManager<TContext, T, TId>
        where TContext : DbContext, new()
        where T : Product
    {
        public ProductManager(TContext context) : base(context)
        {
        }

        //public async Task<IEnumerable<T>> GetProductsByCategoryAsync(string categoryName)
        //{
        //    IQueryable<Product> query = context.Set<Product>().Include(p => p.Category);

        //    if (!string.IsNullOrWhiteSpace(categoryName))
        //    {
        //        query = query.Where(p => p.Category.CategoryName == categoryName);
        //    }

        //    return await query.Cast<T>().ToListAsync();
        //}
        public async Task<IEnumerable<T>> GetProductsByCategoryAsync(Expression<Func<T, bool>>? filter, params Expression<Func<T, object>>[] include)
        {
            IQueryable<T> query = context.Set<T>();

            if (filter != null)
            {
                query = query.Where(filter);
            }

            return await include.Aggregate(query, (current, includeProperty) => current.Include(includeProperty)).ToListAsync();
        }
    }
}
