using MediatR;
using PhotoStock.Api.Features.AddPhoto;
using Shared.Extensions;
using System.Diagnostics;

namespace PhotoStock.Api.Features
{
    public static class DeletePhotoEndpoint
    {
        public static RouteGroupBuilder DeletePhotoGroupItemEndpoint(this RouteGroupBuilder group)
        {
            group.MapDelete("/", async (string url, IMediator mediator)
                => (await mediator.Send(new DeletePhotoCommand(url))).ToGenericResult())
                .WithName("DeletePhoto")
                .MapToApiVersion(1, 0);

            return group;
        }
    }
}
