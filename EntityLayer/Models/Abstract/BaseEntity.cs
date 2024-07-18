using EntityLayer.Models.Concrete;

namespace EntityLayer.Models.Abstract
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now;
        public string? MyUserId { get; set; }

        public MyUser? MyUser { get; set; }
    }
}
