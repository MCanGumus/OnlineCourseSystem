using CatalogService.Api.Features.Courses.Commands.Create;
using CatalogService.Api.Features.Courses.Dtos;

namespace CatalogService.Api.Features.Courses
{
    public class CourseMapping : Profile
    {
        public CourseMapping()
        {
            CreateMap<CreateCourseCommand, Course>().ReverseMap();
            CreateMap<Course, CourseDto>().ReverseMap();
            CreateMap<Feature, FeatureDto>().ReverseMap();
        }
    }
}
