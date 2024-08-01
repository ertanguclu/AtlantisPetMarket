using BusinessLayer.Abstract;
using EntityLayer.Models.Concrete;
using Microsoft.EntityFrameworkCore;

namespace BusinessLayer.Concrete
{
    public class SocialMediaManager<TContext, T, TId> : GenericManager<TContext, T, TId>, ISocialMediaManager<TContext, T, TId>
        where TContext : DbContext, new()
        where T : SocialMedia
    {
        public SocialMediaManager(TContext context) : base(context)
        {
        }
    }
}
