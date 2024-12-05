using BasketService.Api.Features.Baskets.Commands.DeleteBasketItem;
using MediatR;
using Shared.Extensions;
using Shared.Filters;

namespace BasketService.Api.Features.Baskets.Queries.GetBasket
{
    public static class GetBasketQueryEndpoint
    {
        public static RouteGroupBuilder GetBasketGroupItemEndpoint(this RouteGroupBuilder group)
        {
            group.MapGet("/user", async (IMediator mediator)
                => (await mediator.Send(new GetBasketQuery())).ToGenericResult())
                .WithName("GetBasket")
                .MapToApiVersion(1, 0);

            return group;
        }
    }
}
