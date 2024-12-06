using MediatR;
using PhotoStock.Api.Dto;
using Shared;

namespace PhotoStock.Api.Features
{
    public class DeletePhotoCommandHandler : IRequestHandler<DeletePhotoCommand, ServiceResult>
    {
        public async Task<ServiceResult> Handle(DeletePhotoCommand request, CancellationToken cancellationToken)
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/photos", request.photoUrl);

            if (!File.Exists(path)) 
            {
                return ServiceResult.Error("The file is not found", "The requested file is not found", System.Net.HttpStatusCode.NotFound);    
            }

            File.Delete(path);

            return ServiceResult.SuccessAsNoContent();
        }
    }
}
