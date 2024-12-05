using FluentValidation;

namespace BasketService.Api.Features.Baskets.Commands.ApplyDiscountCoupon
{
    public class ApplyDiscountCouponCommandValidator : AbstractValidator<ApplyDiscountCouponCommand>
    {
        public ApplyDiscountCouponCommandValidator()
        {
            RuleFor(x => x.Coupon).NotEmpty().WithMessage("Coupon is required.");
            RuleFor(x => x.DiscountRate).GreaterThan(0).WithMessage("DiscountRate is must be greater than zero.");
        }
    }
}
