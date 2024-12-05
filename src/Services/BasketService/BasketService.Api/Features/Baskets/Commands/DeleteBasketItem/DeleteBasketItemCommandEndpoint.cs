using BasketService.Api.Features.Baskets.Commands.AddBasketItem;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shared.Extensions;
using Shared.Filters;

namespace BasketService.Api.Features.Baskets.Commands.DeleteBasketItem
{
    public static class DeleteBasketItemCommandEndpoint
    {
        public static RouteGroupBuilder DeleteBasketItemGroupItemEndpoint(this RouteGroupBuilder group)
        {
            group.MapDelete("/item/{courseId:guid}", async (Guid courseId, IMediator mediator)
                => (await mediator.Send(new DeleteBasketItemCommand(courseId))).ToGenericResult())
                .WithName("DeleteBasket")
                .MapToApiVersion(1, 0)
                .AddEndpointFilter<ValidationFilter<DeleteBasketItemCommandValidator>>();

            return group;
        }
    }
}
