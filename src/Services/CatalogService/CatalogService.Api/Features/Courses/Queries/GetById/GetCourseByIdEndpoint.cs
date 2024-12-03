using CatalogService.Api.Features.Categories.Queries.GetById;
using CatalogService.Api.Features.Courses.Dtos;

namespace CatalogService.Api.Features.Courses.Queries.GetById
{
    public static class GetCourseByIdEndpoint
    {
        public static RouteGroupBuilder GetCourseByIdGroupItemEndpoint(this RouteGroupBuilder group)
        {
            group.MapGet("/getbyid/{id:guid}", async (IMediator mediator, Guid id)
                => (await mediator.Send(new GetCourseByIdQuery(id))).ToGenericResult()).MapToApiVersion(1, 0);

            return group;
        }
    }
}
