using System.Collections.Generic;
using DemoPostman.Models;
using DemoPostman.Services;
using Xunit;

namespace DemoPostman.UnitTests
{
    public class ShoppingcartServiceTests
    {
        private readonly ShoppingCartService shoppingCartService = new ShoppingCartService();


        private readonly PriceDetails expectedPriceDetails = new PriceDetails()
        {
            SelectedProducts = new List<Product>()
            {
              new Product { Name = "Prod1", Description = "Prod1", Price = 10M },
              new Product { Name = "Prod2", Description = "Prod2", Price = 15.99M }
            },
            DiscountedPrice = 23.391M,
            RebateValue = 2.599M,
            TotalPrice = 25.99M
        };

        [Fact]
        public void GetShoppingCartDetails_ValidRequest_ShouldNotApplyRebate()
        {
            var shoppingCart = new ShoppingCart
            {
                CartId = "0000-0000-0000-0000",
                CartProducts = new List<Product>
                {
                  new Product { Name = "Prod1", Description = "Prod1", Price = 2M },
                  new Product { Name = "Prod2", Description = "Prod2", Price = 3M }
                }
            };

            var totalResult = shoppingCartService.GetShoppingCartDetails(shoppingCart);

            Assert.Equal(0, totalResult.RebateValue);
        }


        [Fact]
        public void GetShoppingCartDetails_ValidRequest_ShouldReturnCorrectTotalResult()
        {
            var shoppingCart = new ShoppingCart
            {
                CartId = "0000-0000-0000-0000",
                CartProducts = new List<Product>
                {
                  new Product { Name = "Prod1", Description = "Prod1", Price = 10M },
                  new Product { Name = "Prod2", Description = "Prod2", Price = 15.99M }
                }
            };

            var totalResult = shoppingCartService.GetShoppingCartDetails(shoppingCart);

            Assert.Equal(totalResult.DiscountedPrice, expectedPriceDetails.DiscountedPrice);
            Assert.Equal(totalResult.TotalPrice, expectedPriceDetails.TotalPrice);
            Assert.Equal(totalResult.RebateValue, expectedPriceDetails.RebateValue);
        }
    }
}
