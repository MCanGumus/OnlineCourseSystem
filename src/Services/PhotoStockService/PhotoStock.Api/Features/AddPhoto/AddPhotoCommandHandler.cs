using MediatR;
using PhotoStock.Api.Dto;
using Shared;

namespace PhotoStock.Api.Features.AddPhoto
{
    public class AddPhotoCommandHandler : IRequestHandler<AddPhotoCommand, ServiceResult<PhotoDto>>
    {
        public async Task<ServiceResult<PhotoDto>> Handle(AddPhotoCommand request, CancellationToken cancellationToken)
        {
            if (request.Photo is not null && request.Photo.Length > 0)
            {
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/photos", request.Photo.FileName);

                using var stream = new FileStream(path, FileMode.Create);

                await request.Photo.CopyToAsync(stream, cancellationToken);

                var returnPath = "photos/" + request.Photo.FileName;

                PhotoDto photo = new PhotoDto() { Url = returnPath };

                return ServiceResult<PhotoDto>.SuccessAsCreated(photo, "");
            }

            return ServiceResult<PhotoDto>.Error("Photo is empty", "Photo is empty", System.Net.HttpStatusCode.BadRequest);
        }
    }
}
