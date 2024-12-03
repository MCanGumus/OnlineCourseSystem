namespace CatalogService.Api.Features.Courses.Commands.Update
{
    public class UpdateCourseCommandValidator : AbstractValidator<UpdateCourseCommand>
    {
        public UpdateCourseCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required.")
                .MaximumLength(100).WithMessage("Name must not exceed 100 characters.");

            RuleFor(x => x.Description) // IRuleBuilderInitial<CreateCourseCommand,_>
                .NotEmpty().WithMessage("Description is required.")
                .MaximumLength(1000).WithMessage("Description must not exceed 1000 characters.");

            RuleFor(x => x.Price)// IRuleBuilderInitial<CreateCourseCommand,_>
                .GreaterThan(0).WithMessage("Price must be greater than 0.");

            RuleFor(x => x.CategoryId) // IRuleBuilderInitial<CreateCourseCommand, .. >
                .NotEmpty().WithMessage("Category is required.");
        }
    }
}
