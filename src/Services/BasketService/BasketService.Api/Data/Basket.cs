using BasketService.Api.Dto;
using System.Text.Json.Serialization;

namespace BasketService.Api.Data
{
    public class Basket
    {
        public Guid UserId { get; set; }
        public List<BasketItem> BasketItems { get; set; } = new();
        public float? DiscountRate { get; set; }
        public string? Coupon { get; set; }

        [JsonIgnore]public bool IsApplyDiscount => DiscountRate is > 0 && !string.IsNullOrEmpty(Coupon);
        [JsonIgnore] public decimal TotalPrice => BasketItems.Sum(x => x.Price);
        [JsonIgnore]public decimal? TotalPriceWithDiscount =>
            !IsApplyDiscount ? null : BasketItems.Sum(x => x.PriceByApplyDiscountRate);

        public Basket(Guid userId, List<BasketItem> basketItems)
        {
            UserId = userId;
            BasketItems = basketItems;
        }
        public Basket()
        {

        }
        public void ApplyNewDiscount(string coupon, float discountRate)
        {
            Coupon = coupon;
            DiscountRate = discountRate;

            foreach (var basket in BasketItems)
            {
                basket.PriceByApplyDiscountRate = basket.Price * (decimal)(1 - discountRate);
            }
        }

        public void ApplyAvailableDiscount()
        {
            if (!IsApplyDiscount) 
            {
                return;
            }
            foreach (var basket in BasketItems)
            {
                basket.PriceByApplyDiscountRate = basket.Price * (decimal)(1 - DiscountRate!);
            }
        }

        public void ClearDiscount()
        {
            Coupon = null;
            DiscountRate = null;

            foreach (var basket in BasketItems)
            {
                basket.PriceByApplyDiscountRate = null;
            }
        }


    }
}
