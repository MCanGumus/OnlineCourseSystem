using BasketService.Api.Data;
using BasketService.Api.Dto;
using Shared;

namespace BasketService.Api.Features.Baskets.Queries.GetBasket
{
    public record GetBasketQuery : IRequestByServiceResult<BasketDto>;
}
