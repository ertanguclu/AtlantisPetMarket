using BusinessLayer.Models.SocialMediaVM;
using FluentValidation;

namespace BusinessLayer.ValidationsRules.SocialMediaValidator
{
    public class SocialMediaUpdateValidator : AbstractValidator<SocialMediaUpdateVM>
    {
        public SocialMediaUpdateValidator()
        {
            RuleFor(s => s.Name)
                .NotEmpty().WithMessage("Sosyal medya adı boş geçilemez.")
                .MaximumLength(15).WithMessage("Ad alanı en fazla 15 karakter olabilir.");
            RuleFor(s => s.Url)
                .NotEmpty().WithMessage("Url alanı boş geçilemez.");
            RuleFor(s => s.Icon)
                .NotEmpty().WithMessage("Icon alanı boş geçilemez.");
        }
    }
}
