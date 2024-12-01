using CatalogService.Api.Features.Courses.Commands.Create;

namespace CatalogService.Api.Features.Courses
{
    public class CourseMapping : Profile
    {
        public CourseMapping()
        {
             CreateMap<CreateCourseCommand, Course>().ReverseMap();
        }
    }
}
