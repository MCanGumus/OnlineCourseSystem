using AutoMapper;
using CatalogService.Api.Features.Courses.Dtos;
using CatalogService.Api.Features.Courses.Queries.GetById;

namespace CatalogService.Api.Features.Courses.Queries.GetAllByUserId
{
    public static class GetAllCoursesByUserIdQueryEndpoint
    {
        public static RouteGroupBuilder GetCoursesByUserIdGroupItemEndpoint(this RouteGroupBuilder group)
        {
            group.MapGet("/user/{userId:guid}", async (IMediator mediator, Guid userId)
                => (await mediator.Send(new GetAllCoursesByUserIdQuery(userId))).ToGenericResult()).MapToApiVersion(1, 0);

            return group;
        }
    }
}
