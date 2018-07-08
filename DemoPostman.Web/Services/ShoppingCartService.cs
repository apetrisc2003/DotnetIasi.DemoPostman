using DemoPostman.Interfaces;
using DemoPostman.Models;

namespace DemoPostman.Services
{
    public class ShoppingCartService : IShoppingCartService
    {
        public PriceDetails GetShoppingCartDetails(ShoppingCart shoppingCart)
        {
            var totalResult = new PriceDetails
            {
                SelectedProducts = shoppingCart.CartProducts
            };

            foreach (var product in shoppingCart.CartProducts)
            {
                totalResult.TotalPrice += product.Price;
            }

            //apply rebate of 10% if total exceeds 20M
            if (totalResult.TotalPrice > 20M)
            {
                totalResult.RebateValue = totalResult.TotalPrice * 0.1M;
                totalResult.DiscountedPrice = totalResult.TotalPrice - totalResult.RebateValue;
            }

            return totalResult;
        }
    }
}
