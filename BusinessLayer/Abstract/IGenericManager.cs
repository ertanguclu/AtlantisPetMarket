using DataAccessLayer.Abstract;
using EntityLayer.Models.Abstract;
using Microsoft.EntityFrameworkCore;

namespace BusinessLayer.Abstract
{
    public interface IGenericManager<TContext, T, TId> : IGenericRepository<TContext, T, TId>
       where TContext : DbContext, new()
       where T : BaseEntity
    {

    }
}