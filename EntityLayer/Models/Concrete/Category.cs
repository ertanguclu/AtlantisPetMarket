using EntityLayer.Models.Abstract;
using EntityLayer.Models.Concrete;
using System.Collections.Generic;

namespace EntityLayer.Concrete
{
    public class Category : BaseEntity
    {
        public string CategoryName { get; set; }

        //public string Description { get; set; }

        public string CategoryPhotoPath { get; set; }

        public int ParentCategoryId { get; set; }

        public ParentCategory ParentCategory { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
