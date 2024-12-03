namespace CatalogService.Api.Features.Categories.Commands.Update
{
    public class UpdateCategoryCommandHandler(AppDbContext context) : IRequestHandler<UpdateCategoryCommand, ServiceResult<UpdateCategoryResponse>>
    {
        public async Task<ServiceResult<UpdateCategoryResponse>> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await context.Categories.SingleOrDefaultAsync(x => x.Id == request.Id);

            if (category is null)
                return ServiceResult<UpdateCategoryResponse>.Error("The requested category is not found.", HttpStatusCode.NotFound);

            var nameCheck = await context.Categories.AnyAsync(x => x.Name == request.Name);

            if (nameCheck)
                return ServiceResult<UpdateCategoryResponse>.Error("Category Name already exists.", $"The category name '{request.Name}' already exists", HttpStatusCode.BadRequest);

            category.Name = request.Name;

            context.Categories.Update(category);

            await context.SaveChangesAsync();

            return ServiceResult<UpdateCategoryResponse>.SuccessAsOk(new UpdateCategoryResponse(category.Id, category.Name));
        }
    }
}
