using Asp.Versioning.Builder;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shared.Extensions;
using Shared.Filters;

namespace CatalogService.Api.Features.Categories.Commands.Create
{
    public static class CreateCategoryEndpoint
    {
        public static RouteGroupBuilder CreateCategoryGroupItemEndpoint(this RouteGroupBuilder group)
        {
            group.MapPost("/createcategory", async (CreateCategoryCommand command, IMediator mediator)
                => (await mediator.Send(command)).ToGenericResult())
                .WithName("CreateCategory")
                .MapToApiVersion(1, 0)
                .AddEndpointFilter<ValidationFilter<CreateCategoryCommand>>();

            return group;
        }
    }
}
