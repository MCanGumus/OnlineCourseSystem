using AutoMapper;
using BasketService.Api.Data;
using BasketService.Api.Dto;

namespace BasketService.Api.Features.Baskets
{
    public class BasketMapping : Profile
    {
        public BasketMapping() 
        {
            CreateMap<BasketDto, Basket>().ReverseMap();
            CreateMap<BasketItemDto, BasketItem>().ReverseMap();
        }
    }
}
