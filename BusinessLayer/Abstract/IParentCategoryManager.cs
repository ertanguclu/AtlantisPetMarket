using EntityLayer.Models.Concrete;
using Microsoft.EntityFrameworkCore;

namespace BusinessLayer.Concrete
{
    public interface IParentCategoryManager<TContext, T, TId>
        where TContext : DbContext, new()
        where T : ParentCategory
    {
    }
}