using CatalogService.Api.Features.Categories.Commands.Create;
using Shared.Filters;

namespace CatalogService.Api.Features.Courses.Commands.Create
{
    public static class CreateCourseCommandEndpoint
    {
        public static RouteGroupBuilder CreateCourseGroupItemEndpoint(this RouteGroupBuilder group)
        {
            group.MapPost("/createcourse", async (CreateCourseCommand command, IMediator mediator)
                => (await mediator.Send(command)).ToGenericResult()).AddEndpointFilter<ValidationFilter<CreateCourseCommand>>();

            return group;
        }
    }
}
