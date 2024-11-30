using CatalogService.Api.Features.Categories.Create;
using Shared.Filters;

namespace CatalogService.Api.Features.Categories.Update
{
    public static class UpdateCategoryEndpoint
    {
        public static RouteGroupBuilder UpdateCategoryGroupItemEndpoint(this RouteGroupBuilder group)
        {
            group.MapPost("/updatecategory", async (UpdateCategoryCommand command, IMediator mediator)
                => (await mediator.Send(command)).ToGenericResult()).AddEndpointFilter<ValidationFilter<UpdateCategoryCommand>>();

            return group;
        }
    }
}
