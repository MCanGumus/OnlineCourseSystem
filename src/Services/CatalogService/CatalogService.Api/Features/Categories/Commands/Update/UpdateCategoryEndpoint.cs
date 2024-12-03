using Shared.Filters;

namespace CatalogService.Api.Features.Categories.Commands.Update
{
    public static class UpdateCategoryEndpoint
    {
        public static RouteGroupBuilder UpdateCategoryGroupItemEndpoint(this RouteGroupBuilder group)
        {
            group.MapPut("/updatecategory", async (UpdateCategoryCommand command, IMediator mediator)
                => (await mediator.Send(command)).ToGenericResult()).AddEndpointFilter<ValidationFilter<UpdateCategoryCommand>>()
                .MapToApiVersion(1, 0);

            return group;
        }
    }
}
