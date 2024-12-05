using BasketService.Api.Const;
using BasketService.Api.Data;
using Microsoft.Extensions.Caching.Distributed;
using Shared.Services;
using System.Text.Json;
using System.Threading;

namespace BasketService.Api.Features.Baskets
{
    public class BasketService(IDistributedCache distCache, IIdentityService identityService)
    {
        private string GetCacheKey() => string.Format(BasketConst.BasketCacheKey, identityService.GetUserId);
        

        public Task<string?> GetBasketFromCache(CancellationToken cancellationToken)
        {
            return distCache.GetStringAsync(GetCacheKey(), cancellationToken);
        }

        public async Task CreateBasketCacheAsync(Basket basket, CancellationToken cancellationToken)
        {
            var basketAsString = JsonSerializer.Serialize(basket);

            await distCache.SetStringAsync(GetCacheKey(), basketAsString, token: cancellationToken);
        }
    }
}
