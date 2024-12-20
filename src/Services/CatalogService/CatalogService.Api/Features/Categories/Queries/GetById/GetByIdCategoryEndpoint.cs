﻿
namespace CatalogService.Api.Features.Categories.Queries.GetById
{
    public static class GetByIdCategoryEndpoint
    {
        public static RouteGroupBuilder GetByIdCategoryGroupItemEndpoint(this RouteGroupBuilder group)
        {
            group.MapGet("/getbyid/{id:guid}", async (IMediator mediator, Guid id)
                => (await mediator.Send(new GetByIdCategoryQuery(id))).ToGenericResult()).MapToApiVersion(1, 0);

            return group;
        }
    }
}
