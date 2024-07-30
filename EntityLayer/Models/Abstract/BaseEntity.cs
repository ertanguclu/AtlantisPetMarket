using EntityLayer.Models.Concrete;

namespace EntityLayer.Models.Abstract
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now;
        public string? UserId { get; set; }

        public User? User { get; set; }
    }
}
