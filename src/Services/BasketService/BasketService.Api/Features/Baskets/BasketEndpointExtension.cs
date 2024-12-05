using Asp.Versioning.Builder;
using BasketService.Api.Features.Baskets.Commands.AddBasketItem;
using BasketService.Api.Features.Baskets.Commands.ApplyDiscountCoupon;
using BasketService.Api.Features.Baskets.Commands.DeleteBasketItem;
using BasketService.Api.Features.Baskets.Commands.RemoveDiscountCoupon;
using BasketService.Api.Features.Baskets.Queries.GetBasket;

namespace BasketService.Api.Features.Baskets
{
    public static class BasketEndpointExtension
    {
        public static void AddBasketGroupEndpointExt(this WebApplication app, ApiVersionSet apiVersionSet)
        {
            app.MapGroup("api/v{version:apiVersion}/baskets").WithTags("Basket")
                .WithApiVersionSet(apiVersionSet)
                .AddBasketItemGroupItemEndpoint()
                .DeleteBasketItemGroupItemEndpoint()
                .GetBasketGroupItemEndpoint()
                .ApplyDiscountCouponItemGroupItemEndpoint()
                .RemoveDiscountCouponItemGroupItemEndpoint();
        }
    }
}
