using DemoPostman.Models;
using DemoPostman.Services;
using Xunit;

namespace DemoPostman.UnitTests
{
    public class ProductServiceTests
    {
        private readonly ProductService productService = new ProductService();

        [Fact]
        public void GetProductDetails_ValidId_ShouldReturnProductDetails()
        {
            var product = new Product { Name = "Prod3", Description = "Prod3", Price = 5M };

            var result = productService.GetProductDetails(3);

            Assert.Equal(product.Name, result.Name);
        }
    }
}
