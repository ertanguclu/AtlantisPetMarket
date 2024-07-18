using BusinessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Models.Abstract;
using Microsoft.EntityFrameworkCore;

namespace BusinessLayer.Concrete
{
    public class GenericManager<TContext, T, TId> : GenericRepository<TContext, T, TId>, IGenericManager<TContext, T, TId>
        where TContext : DbContext, new()
        where T : BaseEntity
    {
        public GenericManager(TContext context) : base(context)
        {

        }
    }
}
