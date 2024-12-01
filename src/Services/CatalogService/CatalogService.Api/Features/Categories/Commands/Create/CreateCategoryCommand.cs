using MediatR;
using Shared;

namespace CatalogService.Api.Features.Categories.Commands.Create
{
    public record CreateCategoryCommand(string Name) : IRequestByServiceResult<CreateCategoryResponse>
    {
    }
}
