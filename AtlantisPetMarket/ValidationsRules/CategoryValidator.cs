
using AtlantisPetMarket.Models.CategoryVM;
using FluentValidation;

namespace BusinessLayer.ValidationsRules
{
    public class CategoryValidator : AbstractValidator<object>
    {
        public CategoryValidator()
        {

            When(x => x is CategoryInsertVM, () =>
            {
                RuleFor(x => ((CategoryInsertVM)x).CategoryName).NotEmpty().WithMessage("Kategori adı boş geçilemez.");
                RuleFor(x => ((CategoryInsertVM)x).CategoryName).MinimumLength(3).WithMessage("Kategori adı en az 3 karakterden oluşmak zorundadır.");
                RuleFor(x => ((CategoryInsertVM)x).CategoryName).MaximumLength(50).WithMessage("Kategori adı en fazla 50 karakter olabilir.");

            });
            When(x => x is CategoryUpdateVM, () =>
            {

                RuleFor(x => ((CategoryUpdateVM)x).CategoryName).NotEmpty().WithMessage("Kategori adı boş geçilemez.");
                RuleFor(x => ((CategoryUpdateVM)x).CategoryName).MinimumLength(3).WithMessage("Kategori adı en az 3 karakterden oluşmak zorundadır.");
                RuleFor(x => ((CategoryUpdateVM)x).CategoryName).MaximumLength(50).WithMessage("Kategori adı en fazla 50 karakter olabilir.");

            });

        }
    }
}
