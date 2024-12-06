using PhotoStock.Api.Dto;
using Shared;

namespace PhotoStock.Api.Features.AddPhoto
{
    public record AddPhotoCommand(IFormFile Photo) : IRequestByServiceResult<PhotoDto>;
}
