using AtlantisPetMarket.Models.ProductVM;
using FluentValidation;
using System.Globalization;

namespace AtlantisPetMarket.ValidationsRules
{
    public class ProductValidator : AbstractValidator<ProductUpdateVM>
    {
        public ProductValidator()
        {
            RuleFor(x => x.Brand)
                .NotEmpty().WithMessage("Marka alanı boş geçilemez.")
                .MinimumLength(2).WithMessage("Marka alanı en az 2 karakter olabilir.")
                .MaximumLength(50).WithMessage("Marka alanı en fazla 50 karakter olabilir.");
            RuleFor(x => x.ProductName)
                .NotEmpty().WithMessage("Ürün adı alanı boş geçilemez.")
                .MinimumLength(2).WithMessage("Ürün adı alanı en az 2 karakter olabilir.")
                .MaximumLength(50).WithMessage("Ürün adı alanı en fazla 50 karakter olabilir.");
            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Açıklama alanı boş geçilemez.")
                .MinimumLength(2).WithMessage("Açıklama alanı en az 2 karakter olabilir.")
                .MaximumLength(500).WithMessage("Açıklama alanı en fazla 500 karakter olabilir.");
            RuleFor(x => x.Price)
                .NotEmpty().WithMessage("Fiyat alanı boş geçilemez.")
                .GreaterThanOrEqualTo(1).WithMessage("Fiyat alanı 1 veya daha büyük olmalıdır.")
                .Must(BeAValidPrice).WithMessage("Fiyat alanı geçerli bir sayı olmalıdır ve 0'dan büyük olmalıdır.");
            RuleFor(x => x.ProductCode)
                .NotEmpty().WithMessage("Ürün kodu alanı boş geçilemez.")
                .MinimumLength(2).WithMessage("Ürün kodu alanı en az 2 karakter olabilir.")
                .MaximumLength(50).WithMessage("Ürün kodu alanı en fazla 50 karakter olabilir.");
            RuleFor(x => x.StockQuantity)
                .NotEmpty().WithMessage("Stok miktarı alanı boş geçilemez.")
                .GreaterThan(0).WithMessage("Stok miktarı alanı 0'dan büyük olmalıdır.");
            RuleFor(x => x.ProductPhotoPath)
                .NotEmpty().WithMessage("Ürün fotoğraf yolu alanı boş geçilemez.")
                .MinimumLength(2).WithMessage("Ürün fotoğraf yolu alanı en az 2 karakter olabilir.")
                .MaximumLength(250).WithMessage("Ürün fotoğraf yolu alanı en fazla 250 karakter olabilir.");
            RuleFor(x => x.Color)
                .MaximumLength(50).WithMessage("Renk alanı en fazla 50 karakter olabilir.");

            bool BeAValidPrice(decimal price)
            {
                // Fiyatı tr-TR kültürü ile string olarak al ve parse et
                var priceString = price.ToString(CultureInfo.InvariantCulture);
                if (decimal.TryParse(priceString, NumberStyles.Any, new CultureInfo("tr-TR"), out decimal result))
                {
                    return result >= 1;
                }
                return false;
            }


        }

    }
}
