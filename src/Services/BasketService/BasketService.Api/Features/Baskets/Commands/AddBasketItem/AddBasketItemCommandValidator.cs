﻿using FluentValidation;

namespace BasketService.Api.Features.Baskets.Commands.AddBasketItem
{
    public class AddBasketItemCommandValidator : AbstractValidator<AddBasketItemCommand>
    {
        public AddBasketItemCommandValidator() 
        {
            RuleFor(x => x.CourseId).NotEmpty().WithMessage("CourseId is required.");
            RuleFor(x => x.CoursePrice).GreaterThan(0).WithMessage("CoursePrice must be greater than zero.");
            RuleFor(x => x.CourseName).NotEmpty().WithMessage("CourseName is required.");
        }
    }
}
