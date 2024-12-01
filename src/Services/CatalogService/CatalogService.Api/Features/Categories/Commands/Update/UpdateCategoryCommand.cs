namespace CatalogService.Api.Features.Categories.Commands.Update
{
    public record UpdateCategoryCommand(Guid Id, string Name) : IRequestByServiceResult<UpdateCategoryResponse>;
}
