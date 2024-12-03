using CatalogService.Api.Features.Courses.Dtos;

namespace CatalogService.Api.Features.Courses.Queries.GetById
{
    public class GetCourseByIdQueryHandler(AppDbContext context, IMapper mapper) : IRequestHandler<GetCourseByIdQuery, ServiceResult<CourseDto>>
    {
        public async Task<ServiceResult<CourseDto>> Handle(GetCourseByIdQuery request, CancellationToken cancellationToken)
        {
            var hasCourse = await context.Courses.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken: cancellationToken);

            if (hasCourse is null)
            {
                return ServiceResult<CourseDto>.Error("Course is not found", $"The course with id {request.Id} was not found", HttpStatusCode.NotFound);
            }

            var category = await context.Categories.FindAsync(hasCourse.CategoryId, cancellationToken);

            hasCourse.Category = category!;

            var courseDto = mapper.Map<CourseDto>(hasCourse);

            return ServiceResult<CourseDto>.SuccessAsOk(courseDto);
        }
    }

}
