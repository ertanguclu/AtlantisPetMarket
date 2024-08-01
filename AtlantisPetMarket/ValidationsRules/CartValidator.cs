﻿using FluentValidation;
using AtlantisPetMarket.Models.CartVM;

public class CartValidator : AbstractValidator<CartInsertVM>
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
