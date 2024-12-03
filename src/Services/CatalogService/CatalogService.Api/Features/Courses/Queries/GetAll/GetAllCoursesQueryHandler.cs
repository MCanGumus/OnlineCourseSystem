using CatalogService.Api.Features.Courses.Dtos;

namespace CatalogService.Api.Features.Courses.Queries.GetAll
{
    public class GetAllCoursesQueryHandler(AppDbContext context, IMapper mapper) : IRequestHandler<GetAllCourseQuery, ServiceResult<List<CourseDto>>>
    {
        public async Task<ServiceResult<List<CourseDto>>> Handle(GetAllCourseQuery request, CancellationToken cancellationToken)
        {
            var courses = await context.Courses.ToListAsync(cancellationToken: cancellationToken);

            var categories = await context.Categories.ToListAsync(cancellationToken: cancellationToken);

            foreach (var course in courses)
                course.Category = categories.First(x => x.Id == course.CategoryId);

            var coursesAsDto = mapper.Map<List<CourseDto>>(courses);

            return ServiceResult<List<CourseDto>>.SuccessAsOk(coursesAsDto);
        }


    }
}
