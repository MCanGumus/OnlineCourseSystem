using CatalogService.Api.Features.Categories.Create;
using CatalogService.Api.Features.Categories.GetAll;
using CatalogService.Api.Features.Categories.GetById;
using CatalogService.Api.Features.Categories.Update;

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
                .UpdateCategoryGroupItemEndpoint();
        }
        
    }
}
