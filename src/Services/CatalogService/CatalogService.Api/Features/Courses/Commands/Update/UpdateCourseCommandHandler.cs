﻿using CatalogService.Api.Features.Courses.Dtos;

namespace CatalogService.Api.Features.Courses.Commands.Update
{
    public class UpdateCourseCommandHandler(AppDbContext context) : IRequestHandler<UpdateCourseCommand, ServiceResult>
    {
        public async Task<ServiceResult> Handle(UpdateCourseCommand request, CancellationToken cancellationToken)
        {
            var hasCourse = await context.Courses.FindAsync(request.Id, cancellationToken);

            if (hasCourse == null)
            {
                return ServiceResult.ErrorAsNotFound();
            }

            hasCourse.Name = request.Name;
            hasCourse.Description = request.Description;
            hasCourse.Price = request.Price;
            hasCourse.ImageUrl = request.ImageUrl;
            hasCourse.CategoryId = request.CategoryId;

            context.Courses.Update(hasCourse);

            await context.SaveChangesAsync();

            return ServiceResult.SuccessAsNoContent();
        }
    }
}
