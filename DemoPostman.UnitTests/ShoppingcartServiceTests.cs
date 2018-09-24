using System.Collections.Generic;
using System.Linq;
using DemoPostman.Models;
using DemoPostman.Web.Interfaces;
using DemoPostman.Web.Services;
using Moq;
using Xunit;

namespace DemoPostman.UnitTests
{
    public class ShoppingCartServiceTests
    {
        private Mock<IProductService> mockProductService;
        private ShoppingCartService shoppingCartService;

        public ShoppingCartServiceTests()
        {
            mockProductService = new Mock<IProductService>();
            shoppingCartService = new ShoppingCartService(mockProductService.Object);
        }

        private readonly PriceDetails expectedPriceDetails = new PriceDetails
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
                CartProducts = new List<int> { 1, 2 }
            };

            mockProductService
                .Setup(service => service.GetProductDetails(1))
                .Returns(new Product{Name = "Prod1", Description = "Prod1", Price = 5M});
            mockProductService
                .Setup(service => service.GetProductDetails(2))
                .Returns(new Product { Name = "Prod2", Description = "Prod2", Price = 10.99M });

            var totalResult = shoppingCartService.GetShoppingCartDetails(shoppingCart);

            Assert.Equal(0, totalResult.RebateValue);
        }


        [Fact]
        public void GetShoppingCartDetails_ValidRequest_ShouldReturnCorrectTotalResult()
        {
            var shoppingCart = new ShoppingCart
            {
                CartId = "0000-0000-0000-0000",
                CartProducts = new List<int>{1,2}
            };
            mockProductService
                .Setup(service => service.GetProductDetails(1))
                .Returns(new Product { Name = "Prod1", Description = "Prod1", Price = 10M });
            mockProductService
                .Setup(service => service.GetProductDetails(2))
                .Returns(new Product { Name = "Prod2", Description = "Prod2", Price = 15.99M });

            var totalResult = shoppingCartService.GetShoppingCartDetails(shoppingCart);

            Assert.Equal(totalResult.DiscountedPrice, expectedPriceDetails.DiscountedPrice);
            Assert.Equal(totalResult.TotalPrice, expectedPriceDetails.TotalPrice);
            Assert.Equal(totalResult.RebateValue, expectedPriceDetails.RebateValue);
        }
    }
}


