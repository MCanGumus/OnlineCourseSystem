using CatalogService.Api.Features.Categories.Create;
using System.Runtime.CompilerServices;

namespace CatalogService.Api.Features.Categories
{
    public static class CategoryEndpointExtension
    {
        public static void AddCategoryGroupEndpointExt(this WebApplication app)
        {
            app.MapGroup("api/categories").CreateCategoryGroupItemEndpoint();
        }
        
    }
}
