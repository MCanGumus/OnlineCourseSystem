using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shared.Extensions;
using Shared.Filters;

namespace PhotoStock.Api.Features.AddPhoto
{
    public static class AddPhotoEndpoint
    {
        [IgnoreAntiforgeryToken]
        public static RouteGroupBuilder AddPhotoGroupItemEndpoint(this RouteGroupBuilder group)
        {

            group.MapPost("/", async (IFormFile command, IMediator mediator)
                => (await mediator.Send(new AddPhotoCommand(command))).ToGenericResult())
                .WithName("AddPhoto")
                .DisableAntiforgery()
                .MapToApiVersion(1, 0);

            return group;
        }
    }
}
