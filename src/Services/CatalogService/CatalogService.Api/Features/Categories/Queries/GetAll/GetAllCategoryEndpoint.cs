
namespace CatalogService.Api.Features.Categories.Queries.GetAll
{

    public static class GetAllCategoryEndpoint
    {
        public static RouteGroupBuilder GetAllCategoryGroupItemEndpoint(this RouteGroupBuilder group)
        {
            group.MapGet("/getallcategory", async (IMediator mediator)
                => (await mediator.Send(new GetAllCategoryQuery())).ToGenericResult()).MapToApiVersion(1, 2);

            return group;
        }
    }
}
