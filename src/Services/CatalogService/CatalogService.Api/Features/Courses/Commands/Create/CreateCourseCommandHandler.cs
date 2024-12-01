namespace CatalogService.Api.Features.Courses.Commands.Create
{
    public class CreateCourseCommandHandler(AppDbContext context, IMapper mapper) : IRequestHandler<CreateCourseCommand, ServiceResult<CreateCourseCommandResponse>>
    {
        public async Task<ServiceResult<CreateCourseCommandResponse>> Handle(CreateCourseCommand request, CancellationToken cancellationToken)
        {
            var anyCategory = await context.Categories.AnyAsync(x => x.Id == request.CategoryId, cancellationToken);

            if (!anyCategory)
            {
                return ServiceResult<CreateCourseCommandResponse>.Error("Category is not found.", $"The category with id({request.CategoryId}) is not found.", HttpStatusCode.NotFound);
            }

            var anyCourse = await context.Courses.AnyAsync(x => x.Name == request.Name, cancellationToken);

            if (anyCourse)
            {
                return ServiceResult<CreateCourseCommandResponse>.Error("Course is already exists.", $"The course with name({request.Name}) is already exists.", HttpStatusCode.BadRequest);
            }

            var newCourse = mapper.Map<Course>(request);
            
            newCourse.Id = NewId.NextSequentialGuid();
            newCourse.CreatedDate = DateTime.Now;
            newCourse.Feature = new Feature
            {
                Duration = 10,
                EducatorName = "Can GÜMÜŞ",
                Rating = 0
            };

            await context.Courses.AddAsync(newCourse);

            await context.SaveChangesAsync(cancellationToken);

            return ServiceResult<CreateCourseCommandResponse>.SuccessAsCreated(new CreateCourseCommandResponse(newCourse.Id), $"/api/courses/{newCourse.Id}");
        }
    }
}
