﻿namespace BasketService.Api.Dto
{
    public record BasketItemDto(
        Guid Id,
        string Name,
        string ImageUrl,
        decimal Price,
        decimal? PriceByApplyDiscountRate);

}
