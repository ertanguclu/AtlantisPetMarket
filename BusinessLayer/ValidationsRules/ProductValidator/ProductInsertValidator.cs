using BusinessLayer.Models.ProductVM;
using FluentValidation;

namespace BusinessLayer.ValidationsRules.ProductValidator
{

    public class ProductInsertValidator : AbstractValidator<ProductInsertVM>
    {
        public ProductInsertValidator()
        {
            RuleFor(x => x.Brand)
            .NotEmpty().WithMessage("Marka alanı boş geçilemez.")
            .MinimumLength(2).WithMessage("Marka alanı en az 2 karakter olabilir.")
            .MaximumLength(50).WithMessage("Marka alanı en fazla 50 karakter olabilir.");

            RuleFor(x => x.ProductName)
                .NotEmpty().WithMessage("Ürün adı  boş geçilemez.")
                .MinimumLength(2).WithMessage("Ürün adı alanı en az 2 karakter olabilir.")
                .MaximumLength(50).WithMessage("Ürün adı alanı en fazla 50 karakter olabilir.");

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Açıklama  boş geçilemez.")
                .MinimumLength(2).WithMessage("Açıklama alanı en az 2 karakter olabilir.")
                .MaximumLength(500).WithMessage("Açıklama alanı en fazla 500 karakter olabilir.");
            RuleFor(x => x.Price)
                .NotEmpty().WithMessage("Fiyat  boş geçilemez.")
                .GreaterThanOrEqualTo(1).WithMessage("Fiyat alanı 0'dan büyük olmalıdır.");

            RuleFor(x => x.ProductCode)
                    .NotEmpty().WithMessage("Ürün kodu  boş geçilemez.")
                    .MinimumLength(2).WithMessage("Ürün kodu alanı en az 2 karakter olabilir.")
                    .MaximumLength(50).WithMessage("Ürün kodu alanı en fazla 50 karakter olabilir.");

            RuleFor(x => x.StockQuantity)
                    .NotEmpty().WithMessage("Stok miktarı boş geçilemez.")
                    .GreaterThanOrEqualTo(0).WithMessage("Stok miktarı 0'dan büyük olmalıdır.");

            RuleFor(x => x.ProductPhotoPath)
                    .NotEmpty().WithMessage("Ürün fotoğrafı boş geçilemez.");


            RuleFor(x => x.Color)
                    .MaximumLength(50).WithMessage("Renk alanı en fazla 50 karakter olabilir.");

            RuleFor(x => x.CategoryId)
                    .NotEmpty().WithMessage("Kategori boş geçilemez");
        }


    }
}
