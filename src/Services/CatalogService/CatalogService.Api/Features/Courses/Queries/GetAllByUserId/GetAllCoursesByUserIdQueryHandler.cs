using CatalogService.Api.Features.Courses.Dtos;

namespace CatalogService.Api.Features.Courses.Queries.GetAllByUserId
{
    public class GetAllCoursesByUserIdQueryHandler(AppDbContext context, IMapper mapper) : IRequestHandler<GetAllCoursesByUserIdQuery, ServiceResult<List<CourseDto>>>
    {
        public async Task<ServiceResult<List<CourseDto>>> Handle(GetAllCoursesByUserIdQuery request, CancellationToken cancellationToken)
        {
            var courses = await context.Courses.Where(x => x.UserId == request.UserId).ToListAsync(cancellationToken: cancellationToken);

            var categories = await context.Categories.ToListAsync(cancellationToken: cancellationToken);

            foreach (var course in courses)
                course.Category = categories.First(x => x.Id == course.CategoryId);

            var coursesAsDto = mapper.Map<List<CourseDto>>(courses);

            return ServiceResult<List<CourseDto>>.SuccessAsOk(coursesAsDto);
        }
    }
}
