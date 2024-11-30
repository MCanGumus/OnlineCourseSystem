using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shared.Extensions;
using Shared.Filters;

namespace CatalogService.Api.Features.Categories.Create
{
    public static class CreateCategoryEndpoint
    {
        public static RouteGroupBuilder CreateCategoryGroupItemEndpoint(this RouteGroupBuilder group)
        {
            group.MapPost("/createcategory", async (CreateCategoryCommand command, IMediator mediator)
                => (await mediator.Send(command)).ToGenericResult()).AddEndpointFilter<ValidationFilter<CreateCategoryCommand>>();

            return group;
        }
    }
}
