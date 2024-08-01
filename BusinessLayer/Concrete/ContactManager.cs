using BusinessLayer.Abstract;
using EntityLayer.Models.Concrete;
using Microsoft.EntityFrameworkCore;

namespace BusinessLayer.Concrete
{
    public class ContactManager<TContext, T, TId> : GenericManager<TContext, T, TId>, IContactManager<TContext, T, TId>
        where TContext : DbContext, new()
        where T : Contact
    {
        public ContactManager(TContext context) : base(context)
        {
        }
    }
}
