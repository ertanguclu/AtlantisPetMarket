using EntityLayer.Models.Concrete;
using FluentValidation;

namespace TestValidation.ValidationRules
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(p => p.Brand).NotEmpty().WithMessage("Marka alanı boş olamaz.");

        }
    }
}
