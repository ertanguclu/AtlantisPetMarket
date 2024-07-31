using EntityLayer.Models.Concrete;
using FluentValidation;

namespace BusinessLayer.ValidationsRules
{
    public class ParentCategoryValidator : AbstractValidator<ParentCategory>
    {
        public ParentCategoryValidator()
        {
            RuleFor(x => x.ParentCategoryName).NotEmpty().WithMessage("Üst kategori adı boş geçilemez.");
            RuleFor(x => x.ParentCategoryName).MinimumLength(3).WithMessage("Üst kategori adı en az 3 karakterden oluşmak zorundadır.");
            RuleFor(x => x.ParentCategoryName).MaximumLength(50).WithMessage("Üst kategori adı en fazla 50 karakter olabilir.");
        }
    }
}
