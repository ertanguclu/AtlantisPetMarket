using AtlantisPetMarket.Models.CartItemVM;
using FluentValidation;

public class CartItemValidator : AbstractValidator<CartItemViewModel>
{
    public CartItemValidator()
    {
        RuleFor(x => x.ProductId).NotEmpty().WithMessage("Ürün seçilmelidir.");
        RuleFor(x => x.Quantity).GreaterThan(0).WithMessage("Miktar 0'dan büyük olmalıdır.");
    }
}
