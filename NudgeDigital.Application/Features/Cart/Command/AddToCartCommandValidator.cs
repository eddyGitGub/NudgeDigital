﻿using FluentValidation;

namespace NudgeDigital.Application.Features.LaptopConfiguration.Command
{
    public class AddToCartCommandValidator : AbstractValidator<AddToCartCommand>
    {
        public AddToCartCommandValidator()
        {
            RuleFor(c => c.ItemId).NotEmpty().NotEqual(0);
            RuleFor(c => c.Quantity).NotEmpty().NotEqual(0);
            //RuleFor(c => c.SessionId).NotEmpty();
        }
    }
}
