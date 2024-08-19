﻿using EntityLayer.Models.Abstract;

namespace EntityLayer.Models.Concrete
{
    public class ParentCategory : BaseEntity
    {
        public string ParentCategoryName { get; set; }  // Name of the animal it belongs to

        public ICollection<Category> Categories { get; set; }  // Categories that belong to this parent category
    }
}