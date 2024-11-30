using CatalogService.Api.Features.Categories.Dto;

namespace CatalogService.Api.Features.Categories.GetById
{
    public record GetByIdCategoryQuery(Guid Id) : IRequestByServiceResult<CategoryDto>;
}
