namespace CatalogService.Api.Features.Categories.Commands.Delete
{
    public class DeleteCategoryCommandHandler(AppDbContext context) : IRequestHandler<DeleteCategoryCommand, ServiceResult<DeleteCategoryResponse>>
    {
        public async Task<ServiceResult<DeleteCategoryResponse>> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await context.Categories.SingleOrDefaultAsync(x => x.Id == request.Id);

            if (category is null)
            {
                return ServiceResult<DeleteCategoryResponse>.Error("The requested category is not found.", HttpStatusCode.NotFound);
            }

            context.Categories.Remove(category);

            await context.SaveChangesAsync();

            return ServiceResult<DeleteCategoryResponse>.SuccessAsOk(new DeleteCategoryResponse());
        }
    }
}
