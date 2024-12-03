
using CatalogService.Api.Features.Categories.Commands.Delete;
using Microsoft.VisualBasic;

namespace CatalogService.Api.Features.Courses.Commands.Delete
{
    public static class DeleteCourseCommandEndpoint
    {
        public static RouteGroupBuilder DeleteCourseGroupItemEndpoint(this RouteGroupBuilder group)
        {
            group.MapDelete("/delete/{id:guid}", async (IMediator mediator, Guid id)
                => (await mediator.Send(new DeleteCourseCommand(id))).ToGenericResult()).MapToApiVersion(1, 0);

            return group;
        }
    }
}
