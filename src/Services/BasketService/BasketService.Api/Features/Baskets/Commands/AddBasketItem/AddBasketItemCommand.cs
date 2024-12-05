using Shared;

namespace BasketService.Api.Features.Baskets.Commands.AddBasketItem
{
    public record AddBasketItemCommand(
        Guid CourseId,
        string CourseName,
        decimal CoursePrice,
        string? ImageUrl) : IRequestByServiceResult;
}
