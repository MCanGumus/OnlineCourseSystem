using BasketService.Api.Const;
using BasketService.Api.Data;
using BasketService.Api.Dto;
using MediatR;
using Microsoft.Extensions.Caching.Distributed;
using Shared;
using Shared.Services;
using System.Net;
using System.Text.Json;

namespace BasketService.Api.Features.Baskets.Commands.DeleteBasketItem
{
    public class DeleteBasketItemCommandHandler(BasketService basketService) : IRequestHandler<DeleteBasketItemCommand, ServiceResult>
    {
        public async Task<ServiceResult> Handle(DeleteBasketItemCommand request, CancellationToken cancellationToken)
        {
            var basketAsString = await basketService.GetBasketFromCache(cancellationToken);

            if (string.IsNullOrEmpty(basketAsString))
            {
                return ServiceResult.Error("Basket not found", HttpStatusCode.NotFound);
            }

            var currentBasket = JsonSerializer.Deserialize<Basket>(basketAsString);

            var basketItemToDelete = currentBasket!.BasketItems.FirstOrDefault(x => x.Id == request.CourseId);

            if (basketItemToDelete is null)
                return ServiceResult.Error("Basket item is not found", HttpStatusCode.NotFound);

            currentBasket.BasketItems.Remove(basketItemToDelete);

            await basketService.CreateBasketCacheAsync(currentBasket, cancellationToken);

            return ServiceResult.SuccessAsNoContent();
        }
    }
}
