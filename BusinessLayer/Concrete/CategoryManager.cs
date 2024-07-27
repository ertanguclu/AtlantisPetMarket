using BusinessLayer.Abstract;
using EntityLayer.DbContexts;
using EntityLayer.Models.Concrete;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BusinessLayer.Concrete
{
    public class CategoryManager<TContext, T, TId> : GenericManager<TContext, T, TId>, ICategoryManager<TContext, T, TId>
        where TContext : DbContext, new()
        where T : Category
    {

        private readonly TContext _context;

        public CategoryManager(TContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Category>> GetAllAsync(Expression<Func<Category, bool>> filter = null)
        {
            if (filter != null)
            {
                return await _context.Set<Category>().Where(filter).ToListAsync();
            }
            else
            {
                return await _context.Set<Category>().ToListAsync();
            }
        }
    }

}
