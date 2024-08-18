using BusinessLayer.Models.SocialMediaVM;
using FluentValidation;

namespace BusinessLayer.ValidationsRules.SocialMediaValidator
{
    public class SocialMediaInsertValidator : AbstractValidator<SocialMediaInsertVM>
    {
        public SocialMediaInsertValidator()
        {
            RuleFor(s => s.Name)
                .NotEmpty().WithMessage("Sosyal medya adı boş bırakılamaz.")
                .MaximumLength(15).WithMessage("Ad alanı en fazla 15 karakter olabilir.");
            RuleFor(s => s.Url)
                .NotEmpty().WithMessage("Lütfen bir url giriniz.");
            RuleFor(s => s.Icon)
                .NotEmpty().WithMessage("Lütfen bir ikon seçiniz.");

        }
    }
}
