namespace CatalogService.Api.Features.Categories.GetById
{
    public static class GetByIdCategoryEndpoint
    {
        public static RouteGroupBuilder GetByIdCategoryGroupItemEndpoint(this RouteGroupBuilder group)
        {
            group.MapGet("/getbyid/{id:guid}", async (IMediator mediator, Guid id)
                => (await mediator.Send(new GetByIdCategoryQuery(id))).ToGenericResult());

            return group;
        }
    }
}
