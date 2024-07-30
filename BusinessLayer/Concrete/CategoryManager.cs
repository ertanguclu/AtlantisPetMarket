using BusinessLayer.Abstract;
using EntityLayer.Models.Concrete;
using Microsoft.EntityFrameworkCore;

namespace BusinessLayer.Concrete
{
    public class CategoryManager<TContext, T, TId> : GenericManager<TContext, T, TId>, ICategoryManager<TContext, T, TId>
        where TContext : DbContext, new()
        where T : Category
    {
        public CategoryManager(TContext context) : base(context)
        {
        }
    }

}
