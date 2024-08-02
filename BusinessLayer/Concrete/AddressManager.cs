using BusinessLayer.Abstract;
using EntityLayer.Models.Concrete;
using Microsoft.EntityFrameworkCore;

namespace BusinessLayer.Concrete
{
    public class AddressManager<TContext, T, TId> : GenericManager<TContext, T, TId>, IAddressManager<TContext, T, TId>
        where TContext : DbContext, new()
        where T : Address
    {
        public AddressManager(TContext context) : base(context)
        {
        }
    }
}
