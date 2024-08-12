using EntityLayer.Models.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface ICartItemManager<TContext, T, TId> : IGenericManager<TContext, T, TId>
        where TContext : DbContext, new()
        where T : CartItem
    {
        Task<CartItem?> GetByConditionAsync(Expression<Func<CartItem, bool>> predicate);
    }
}
