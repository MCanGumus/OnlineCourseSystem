namespace CatalogService.Api.Features.Categories.Update
{
    public record UpdateCategoryCommand(Guid Id, string Name) : IRequestByServiceResult<UpdateCategoryResponse>;
}
