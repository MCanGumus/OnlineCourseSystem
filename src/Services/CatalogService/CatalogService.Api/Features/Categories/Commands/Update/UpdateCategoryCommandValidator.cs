
namespace CatalogService.Api.Features.Categories.Commands.Update
{
    public class UpdateCategoryCommandValidator : AbstractValidator<UpdateCategoryCommand>
    {
        public UpdateCategoryCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name cannot be empty.")
                .Length(4, 25).WithMessage("Name must be between 4 and 25 characters.");
        }
    }
}
