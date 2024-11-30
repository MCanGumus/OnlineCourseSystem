using CatalogService.Api.Features.Categories.Create;

namespace CatalogService.Api.Features.Categories.Update
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
