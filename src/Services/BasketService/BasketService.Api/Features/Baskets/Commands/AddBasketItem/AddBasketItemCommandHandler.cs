using BasketService.Api.Const;
using BasketService.Api.Data;
using BasketService.Api.Dto;
using MediatR;
using Microsoft.Extensions.Caching.Distributed;
using Shared;
using Shared.Services;
using System.Text.Json;

namespace BasketService.Api.Features.Baskets.Commands.AddBasketItem
{
    public class AddBasketItemCommandHandler(IDistributedCache distCache, IIdentityService identityService, BasketService basketService) : IRequestHandler<AddBasketItemCommand, ServiceResult>
    {
        public async Task<ServiceResult> Handle(AddBasketItemCommand request, CancellationToken cancellationToken)
        {
            var basketAsJson = await basketService.GetBasketFromCache(cancellationToken);

            Basket? currentBasket;
            var newBasketItem = new BasketItem(request.CourseId, request.CourseName, request.ImageUrl, request.CoursePrice, null);

            if (string.IsNullOrEmpty(basketAsJson))
            {
                currentBasket = new Basket(identityService.GetUserId, [newBasketItem]);

                await basketService.CreateBasketCacheAsync(currentBasket, cancellationToken);

                return ServiceResult.SuccessAsNoContent();
            }

            currentBasket = JsonSerializer.Deserialize<Basket>(basketAsJson);

            var existingBasketItem = currentBasket!.BasketItems.FirstOrDefault(x => x.Id == request.CourseId);

            if (existingBasketItem is not null)
                currentBasket.BasketItems.Remove(existingBasketItem);
            
            currentBasket.BasketItems.Add(newBasketItem);

            if (currentBasket.IsApplyDiscount)
            {
                currentBasket.ApplyAvailableDiscount();
            }

            await basketService.CreateBasketCacheAsync(currentBasket, cancellationToken);

            return ServiceResult.SuccessAsNoContent();
        }

        
    }
}
