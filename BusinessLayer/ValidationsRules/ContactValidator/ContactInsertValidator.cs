using BusinessLayer.Models.ContactVM;
using FluentValidation;

namespace BusinessLayer.ValidationsRules.ContactValidator
{
    public class ContactInsertValidator : AbstractValidator<ContactInsertVM>
    {
        public ContactInsertValidator()
        {

            RuleFor(x => x.SellerName).NotEmpty().WithMessage("Satıcı adı boş geçilemez")
                                      .MinimumLength(3).WithMessage("Satıcı adı en az 3 karakter olmalıdır")
                                      .MaximumLength(50).WithMessage("Satıcı adı en fazla 50 karakter olmalıdır");
            RuleFor(x => x.Phone).NotEmpty().WithMessage("Telefon boş geçilemez")
                                    .MinimumLength(10).WithMessage("Telefon en az 10 karakter olmalıdır")
                                    .MaximumLength(10).WithMessage("Telefon en fazla 10 karakter olmalıdır");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email boş geçilemez")
                                 .EmailAddress().WithMessage("Geçerli bir email adresi giriniz");
            RuleFor(x => x.Address).NotEmpty().WithMessage("Adres boş geçilemez")
                                   .MinimumLength(10).WithMessage("Adres en az 10 karakter olmalıdır")
                                   .MaximumLength(200).WithMessage("Adres en fazla 200 karakter olmalıdır");
        }
    }
}
