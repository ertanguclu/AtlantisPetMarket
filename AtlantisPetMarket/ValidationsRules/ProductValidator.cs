using EntityLayer.Models.Concrete;
using FluentValidation;

namespace AtlantisPetMarket.ValidationsRules
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(x => x.Brand).NotEmpty().WithMessage("Marka alanı boş geçilemez.")
                                .NotNull().WithMessage("Marka null olamaz")
            .MinimumLength(3).WithMessage("marka adı en az 3 karakterden oluşmak zorundadır.");
                                
            RuleFor(x => x.ProductName)
            .MinimumLength(3).WithMessage("Ürün adı en az 3 karakterden oluşmak zorundadır.")
            .MaximumLength(50).WithMessage("Ürün adı en fazla 50 karakter olabilir.")
            .NotEmpty().WithMessage("ürün ismi bos olamaz");

            RuleFor(x => x.Description).NotEmpty().WithMessage("Açıklama alanı boş geçilemez.");
            RuleFor(x => x.Description).MinimumLength(3).WithMessage("Açıklama en az 3 karakterden oluşmak zorundadır.");
            RuleFor(x => x.Description).MaximumLength(500).WithMessage("Açıklama en fazla 500 karakter olabilir.");
            RuleFor(x => x.Price).NotEmpty().WithMessage("Fiyat alanı boş geçilemez.");
            RuleFor(x => x.StockQuantity).NotEmpty().WithMessage("Stok miktarı alanı boş geçilemez.");
            RuleFor(x => x.ProductPhotoPath).NotEmpty().WithMessage("Ürün resmi alanı boş geçilemez.");
            RuleFor(x => x.ProductCode).NotEmpty().WithMessage("Ürün kodu alanı boş geçilemez.");


        }
    }
}
