﻿using BusinessLayer.Models.CategoryVM;
using FluentValidation;

namespace BusinessLayer.ValidationsRules.CategoryValidator
{
    public class CategoryInsertValidator : AbstractValidator<CategoryInsertVM>
    {
        public CategoryInsertValidator()
        {

            RuleFor(x => x.CategoryName).NotEmpty().WithMessage("Kategori adı boş geçilemez.");
            RuleFor(x => x.CategoryName).MinimumLength(3).WithMessage("Kategori adı en az 3 karakterden oluşmak zorundadır.");
            RuleFor(x => x.CategoryName).MaximumLength(50).WithMessage("Kategori adı en fazla 50 karakter olabilir.");
            RuleFor(x => x.ParentCategoryId).NotEmpty().WithMessage("Üst kategori boş geçilemez.");

        }
    }
}
