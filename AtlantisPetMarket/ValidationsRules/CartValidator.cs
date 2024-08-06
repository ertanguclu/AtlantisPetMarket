using FluentValidation;
using AtlantisPetMarket.Models.CartViewModel;
using AtlantisPetMarket.Models.CartViewModel;

public class CartValidator : AbstractValidator<CartVM>
{
    public CartValidator()
    {
        RuleFor(cart => cart.UserId)
            .GreaterThan(0)
            .WithMessage("UserId must be greater than 0");

        RuleFor(cart => cart.CreateDateTime)
            .LessThanOrEqualTo(DateTime.Now)
            .WithMessage("CreateDateTime cannot be in the future");
    }
}
