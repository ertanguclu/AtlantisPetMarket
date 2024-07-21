using BusinessLayer.Abstract;
using EntityLayer.Models.Concrete;
using Microsoft.EntityFrameworkCore;

namespace BusinessLayer.Concrete
{
    public class ProductManager<TContext, T, TId> : GenericManager<TContext, T, TId>, IProductManager<TContext, T, TId>
        where TContext : DbContext, new()
        where T : Product
    {
        public ProductManager(TContext context) : base(context)
        {
        }
    }
}
