namespace CatalogService.Api.Features.Categories.Commands.Create
{
    public class CreateCategoryCommandValidator : AbstractValidator<CreateCategoryCommand>
    {
        public CreateCategoryCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name cannot be empty.")
                .Length(4, 25).WithMessage("Name must be between 4 and 25 characters.");
        }
    }
}
