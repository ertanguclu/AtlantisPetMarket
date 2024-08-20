using BusinessLayer.Models.ProductVM;
using FluentValidation;

namespace BusinessLayer.ValidationsRules.ProductValidator
{
    public class ProductUpdateValidator : AbstractValidator<ProductUpdateVM>
    {
        public ProductUpdateValidator()
        {
            RuleFor(x => x.Brand)
                .NotEmpty().WithMessage("Marka alanı boş geçilemez.")
                .MinimumLength(2).WithMessage("Marka alanı en az 2 karakter olabilir.")
                .MaximumLength(50).WithMessage("Marka alanı en fazla 50 karakter olabilir.");

            RuleFor(x => x.ProductName)
                .NotEmpty().WithMessage("Ürün adı  boş geçilemez.")
                .MinimumLength(2).WithMessage("Ürün adı en az 2 karakter olabilir.")
                .MaximumLength(50).WithMessage("Ürün adı  en fazla 50 karakter olabilir.");

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Açıklama alanı boş geçilemez.")
                .MinimumLength(2).WithMessage("Açıklama  en az 2 karakter olabilir.")
                .MaximumLength(500).WithMessage("Açıklama  en fazla 500 karakter olabilir.");
            RuleFor(x => x.Price)
                .NotEmpty().WithMessage("Fiyat boş geçilemez.")
                .GreaterThanOrEqualTo(1).WithMessage("Fiyat 0'dan büyük olmalıdır.");

            RuleFor(x => x.ProductCode)
                    .NotEmpty().WithMessage("Ürün kodu boş geçilemez.")
                    .MinimumLength(2).WithMessage("Ürün kodu en az 2 karakter olabilir.")
                    .MaximumLength(50).WithMessage("Ürün kodu en fazla 50 karakter olabilir.");

            RuleFor(x => x.StockQuantity)
                    .NotEmpty().WithMessage("Stok miktarı boş geçilemez.")
                    .GreaterThan(0).WithMessage("Stok miktarı 0'dan büyük olmalıdır.");

            RuleFor(x => x.ProductPhotoPath)
                    .NotEmpty().WithMessage("Ürün fotoğraf boş geçilemez.");


            RuleFor(x => x.Color)
                    .MaximumLength(50).WithMessage("Renk alanı en fazla 50 karakter olabilir.");
        }
    }
}
