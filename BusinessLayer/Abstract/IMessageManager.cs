using EntityLayer.Models.Concrete;
using Microsoft.EntityFrameworkCore;

namespace BusinessLayer.Abstract
{
    public interface IMessageManager<TContext, T, TId> : IGenericManager<TContext, T, TId>
        where TContext : DbContext, new()
        where T : Message
    {
        Task<List<Message>> GetListReceiverMessage(string receiver);
        Task<List<Message>> GetListSenderMessage(string sender);
    }
}
