using EntityLayer.Models.Concrete;

namespace EntityLayer.Models.Abstract
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now;
        }

}

