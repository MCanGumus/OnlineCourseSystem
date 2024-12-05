using BasketService.Api.Features.Baskets.Commands.ApplyDiscountCoupon;
using MediatR;
using Shared.Extensions;
using Shared.Filters;

namespace BasketService.Api.Features.Baskets.Commands.RemoveDiscountCoupon
{
    public static class RemoveDiscountCouponCommandEndpoint
    {
        public static RouteGroupBuilder RemoveDiscountCouponItemGroupItemEndpoint(this RouteGroupBuilder group)
        {
            group.MapDelete("/removediscountrate", async (IMediator mediator)
                => (await mediator.Send(new RemoveDiscountCouponCommand())).ToGenericResult())
                .WithName("RemoveDiscountRate")
                .MapToApiVersion(1, 0);

            return group;
        }
    }
}
