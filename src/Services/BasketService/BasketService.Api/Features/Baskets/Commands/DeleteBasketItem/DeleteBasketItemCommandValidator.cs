using FluentValidation;

namespace BasketService.Api.Features.Baskets.Commands.DeleteBasketItem
{
    public class DeleteBasketItemCommandValidator : AbstractValidator<DeleteBasketItemCommand>
    {
        public DeleteBasketItemCommandValidator() 
        {
            RuleFor(x => x.CourseId).NotEmpty().WithMessage("CourseId is required");
        }
    }
}
