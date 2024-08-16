using BusinessLayer.Abstract;
using EntityLayer.Models.Concrete;
using Microsoft.EntityFrameworkCore;

namespace BusinessLayer.Concrete
{
    public class MessageManager<TContext, T, TId> : GenericManager<TContext, T, TId>, IMessageManager<TContext, T, TId>
            where TContext : DbContext, new()
            where T : Message
    {
        public MessageManager(TContext context) : base(context)
        {
        }

        public async Task<List<Message>> GetListReceiverMessage(string receiver)
        {
            // Filtreleme işlemi için filter kullanarak GetAllAsync çağrısı yapılıyor
            var result = await GetAllAsync(x => x.Receiver == receiver);
            return result.ToList<Message>(); // Explicitly convert IEnumerable<T> to List<Message>
        }

        public async Task<List<Message>> GetListSenderMessage(string sender)
        {
            // Filtreleme işlemi için filter kullanarak GetAllAsync çağrısı yapılıyor
            var result = await GetAllAsync(x => x.Sender == sender);
            return result.ToList<Message>(); // Explicitly convert IEnumerable<T> to List<Message>
        }
    }
}
