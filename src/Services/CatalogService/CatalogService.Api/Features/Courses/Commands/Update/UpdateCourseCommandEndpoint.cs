using CatalogService.Api.Features.Courses.Commands.Create;
using Shared.Filters;

namespace CatalogService.Api.Features.Courses.Commands.Update
{
    public static class UpdateCourseCommandEndpoint
    {
        public static RouteGroupBuilder UpdateCourseGroupItemEndpoint(this RouteGroupBuilder group)
        {
            group.MapPut("/updatecourse", async (UpdateCourseCommand command, IMediator mediator)
                => (await mediator.Send(command)).ToGenericResult()).AddEndpointFilter<ValidationFilter<UpdateCourseCommand>>().MapToApiVersion(1, 0);

            return group;
        }
    }
}
