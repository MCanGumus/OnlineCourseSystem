﻿using CatalogService.Api.Features.Categories.Dto;

namespace CatalogService.Api.Features.Categories.Queries.GetAll
{
    public class GetAllCategoryHandler(AppDbContext context, IMapper mapper) : IRequestHandler<GetAllCategoryQuery, ServiceResult<List<CategoryDto>>>
    {
        public async Task<ServiceResult<List<CategoryDto>>> Handle(GetAllCategoryQuery request, CancellationToken cancellationToken)
        {
            var categories = await context.Categories.ToListAsync(cancellationToken: cancellationToken);

            var mappedCategories = mapper.Map<List<CategoryDto>>(categories);

            return ServiceResult<List<CategoryDto>>.SuccessAsOk(mappedCategories);
        }
    }
}
