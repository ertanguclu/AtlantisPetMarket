using AtlantisPetMarket.Models.CategoryVM;
using FluentValidation;

namespace AtlantisPetMarket.ValidationsRules
{
    public class CategoryValidator : AbstractValidator<CategoryUpdateVM>
    {
        public CategoryValidator()
        {
            RuleFor(x => x.CategoryName).NotEmpty().WithMessage("Kategori adı boş geçilemez.");
            RuleFor(x => x.CategoryName).MinimumLength(3).WithMessage("Kategori adı en az 3 karakterden oluşmak zorundadır.");
            RuleFor(x => x.CategoryName).MaximumLength(50).WithMessage("Kategori adı en fazla 50 karakter olabilir.");
            //RuleFor(x => x.CategoryPhotoPath).NotEmpty().WithMessage("Kategori fotoğraf alanı boş geçilemez.");

        }
    }
}
