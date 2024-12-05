using MediatR;
using Shared;

namespace BasketService.Api.Features.Baskets.Commands.DeleteBasketItem
{
    public record DeleteBasketItemCommand(Guid CourseId) : IRequestByServiceResult;
}
