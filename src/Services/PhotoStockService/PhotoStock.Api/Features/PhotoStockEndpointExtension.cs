using Asp.Versioning.Builder;
using PhotoStock.Api.Features.AddPhoto;

namespace PhotoStock.Api.Features
{
    public static class PhotoStockEndpointExtension
    {
        public static void AddPhotoStockGroupEndpointExt(this WebApplication app, ApiVersionSet apiVersionSet)
        {
            app.MapGroup("api/v{version:apiVersion}/photos").WithTags("Photos")
                .WithApiVersionSet(apiVersionSet)
                .AddPhotoGroupItemEndpoint()
                .DeletePhotoGroupItemEndpoint();
        }
    }
}
