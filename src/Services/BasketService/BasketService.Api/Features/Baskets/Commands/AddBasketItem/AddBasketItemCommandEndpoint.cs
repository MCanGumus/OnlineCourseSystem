﻿using MediatR;
using Shared.Extensions;
using Shared.Filters;

namespace BasketService.Api.Features.Baskets.Commands.AddBasketItem
{
    public static class AddBasketItemCommandEndpoint
    {
        public static RouteGroupBuilder AddBasketItemGroupItemEndpoint(this RouteGroupBuilder group)
        {
            group.MapPost("/item", async (AddBasketItemCommand command, IMediator mediator)
                => (await mediator.Send(command)).ToGenericResult())
                .WithName("AddBasketItem")
                .MapToApiVersion(1, 0)
                .AddEndpointFilter<ValidationFilter<AddBasketItemCommandValidator>>();

            return group;
        }
    }
}
