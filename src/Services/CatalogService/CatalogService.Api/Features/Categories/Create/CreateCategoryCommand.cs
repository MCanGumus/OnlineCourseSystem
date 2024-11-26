using MediatR;
using Shared;

namespace CatalogService.Api.Features.Categories.Create
{
    public record CreateCategoryCommand(string Name) : IRequest<ServiceResult<CreateCategoryResponse>>
    {
    }
}
