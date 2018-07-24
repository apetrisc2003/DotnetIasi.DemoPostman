using System.Collections.Generic;
using System.Linq;
using DemoPostman.Interfaces;
using DemoPostman.Models;

namespace DemoPostman.Services
{
    public class ShoppingCartService : IShoppingCartService
    {
        private readonly IProductService productService;

        public ShoppingCartService(IProductService productService)
        {
            this.productService = productService;
        }
        public PriceDetails GetShoppingCartDetails(ShoppingCart shoppingCart)
        {
            var selectedProducts = shoppingCart.CartProducts.Select(id => productService.GetProductDetails(id)).ToList();

            var totalResult = new PriceDetails
            {
                SelectedProducts = selectedProducts
            };

            foreach (var product in selectedProducts)
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
