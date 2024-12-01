using CatalogService.Api.Features.Categories.Dto;

namespace CatalogService.Api.Features.Categories.Queries.GetById
{
    public class GetByIdCategoryHandler(AppDbContext context, IMapper mapper) : IRequestHandler<GetByIdCategoryQuery, ServiceResult<CategoryDto>>
    {
        public async Task<ServiceResult<CategoryDto>> Handle(GetByIdCategoryQuery request, CancellationToken cancellationToken)
        {
            var category = await context.Categories.SingleOrDefaultAsync(x => x.Id == request.Id);

            var mappedCategory = mapper.Map<CategoryDto>(category);

            return ServiceResult<CategoryDto>.SuccessAsOk(mappedCategory);
        }
    }
}
