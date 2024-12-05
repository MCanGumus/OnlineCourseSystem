using BasketService.Api.Features.Baskets.Commands.AddBasketItem;
using MediatR;
using Shared.Extensions;
using Shared.Filters;

namespace BasketService.Api.Features.Baskets.Commands.ApplyDiscountCoupon
{
    public static class ApplyDiscountCouponCommandEndpoint
    {
        public static RouteGroupBuilder ApplyDiscountCouponItemGroupItemEndpoint(this RouteGroupBuilder group)
        {
            group.MapPost("/applydiscountrate", async (ApplyDiscountCouponCommand command, IMediator mediator)
                => (await mediator.Send(command)).ToGenericResult())
                .WithName("ApplyDiscountRate")
                .MapToApiVersion(1, 0)
                .AddEndpointFilter<ValidationFilter<ApplyDiscountCouponCommandValidator>>();

            return group;
        }
    }
}
