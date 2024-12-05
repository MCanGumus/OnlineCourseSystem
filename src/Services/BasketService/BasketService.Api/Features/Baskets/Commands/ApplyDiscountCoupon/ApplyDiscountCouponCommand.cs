using Shared;

namespace BasketService.Api.Features.Baskets.Commands.ApplyDiscountCoupon
{
    public record ApplyDiscountCouponCommand(string Coupon, float DiscountRate) : IRequestByServiceResult;
}
