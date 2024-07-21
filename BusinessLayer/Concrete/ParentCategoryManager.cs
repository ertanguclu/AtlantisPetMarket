using BusinessLayer.Abstract;
using EntityLayer.Models.Concrete;
using Microsoft.EntityFrameworkCore;

namespace BusinessLayer.Concrete
{
    public class ParentCategoryManager<TContext, T, TId> : GenericManager<TContext, T, TId>, IParentCategoryManager<TContext, T, TId>
        where TContext : DbContext, new()
        where T : ParentCategory
    {
        public ParentCategoryManager(TContext context) : base(context)
        {
        }
    }

}
