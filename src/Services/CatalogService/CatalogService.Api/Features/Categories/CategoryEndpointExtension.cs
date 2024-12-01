using CatalogService.Api.Features.Categories.Commands.Create;
using CatalogService.Api.Features.Categories.Commands.Delete;
using CatalogService.Api.Features.Categories.Commands.Update;
using CatalogService.Api.Features.Categories.Queries.GetAll;
using CatalogService.Api.Features.Categories.Queries.GetById;

namespace CatalogService.Api.Features.Categories
{
    public static class CategoryEndpointExtension
    {
        public static void AddCategoryGroupEndpointExt(this WebApplication app)
        {
            app.MapGroup("api/categories")
                .CreateCategoryGroupItemEndpoint()
                .GetAllCategoryGroupItemEndpoint()
                .GetByIdCategoryGroupItemEndpoint()
                .UpdateCategoryGroupItemEndpoint()
                .DeleteCategoryGroupItemEndpoint();
        }
        
    }
}
