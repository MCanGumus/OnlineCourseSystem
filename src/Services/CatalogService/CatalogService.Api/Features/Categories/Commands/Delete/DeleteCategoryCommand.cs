namespace CatalogService.Api.Features.Categories.Commands.Delete
{
    public record DeleteCategoryCommand(Guid Id) : IRequestByServiceResult<DeleteCategoryResponse>;
}
