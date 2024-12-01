namespace CatalogService.Api.Features.Categories.Commands.Create
{
    public class CreateCategoryCommandHandler(AppDbContext context) : IRequestHandler<CreateCategoryCommand, ServiceResult<CreateCategoryResponse>>
    {
        public async Task<ServiceResult<CreateCategoryResponse>> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var existCategory = await context.Categories.AnyAsync(x => x.Name == request.Name, cancellationToken: cancellationToken);

            if (existCategory)
            {
                return ServiceResult<CreateCategoryResponse>.Error("Category Name already exists.", $"The category name '{request.Name}' already exists", HttpStatusCode.BadRequest);
            }

            var category = new Category { Name = request.Name, Id = NewId.NextSequentialGuid() };

            await context.Categories.AddAsync(category, cancellationToken);
            await context.SaveChangesAsync();

            return ServiceResult<CreateCategoryResponse>.SuccessAsCreated(new CreateCategoryResponse(category.Id), "<empty>");

        }
    }
}
