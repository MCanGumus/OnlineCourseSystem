using PhotoStock.Api.Dto;
using Shared;

namespace PhotoStock.Api.Features
{
    public record DeletePhotoCommand(string photoUrl) : IRequestByServiceResult;
}
