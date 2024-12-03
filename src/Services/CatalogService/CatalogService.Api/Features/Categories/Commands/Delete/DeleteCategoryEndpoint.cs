
namespace CatalogService.Api.Features.Categories.Commands.Delete
{
    public static class DeleteCategoryEndpoint
    {
        public static RouteGroupBuilder DeleteCategoryGroupItemEndpoint(this RouteGroupBuilder group)
        {
            group.MapDelete("/delete/{id:guid}", async (IMediator mediator, Guid id)
                => (await mediator.Send(new DeleteCategoryCommand(id))).ToGenericResult())
                .MapToApiVersion(1, 0);

            return group;
        }
    }
}
