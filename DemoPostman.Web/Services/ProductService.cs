using System.Collections.Generic;
using DemoPostman.Interfaces;
using DemoPostman.Models;

namespace DemoPostman.Services
{
    public class ProductService : IProductService
    {
        public List<Product> GetProducts()
        {
            return new List<Product>
            {
                new Product {Id = 1, Name = "Prod1", Description = "Prod1", Price = 10M},
                new Product {Id = 2, Name = "Prod2", Description = "Prod2", Price = 15.99M},
                new Product {Id = 3, Name = "Prod3", Description = "Prod3", Price = 5M}
            };
        }

        public Product GetProductDetails(int productId)
        {
            var product = new Product();
            switch (productId)
            {
                case 1:
                    product = new Product { Id = 1, Name = "Prod1", Description = "Prod1", Price = 10M };
                    break;
                case 2:
                    product = new Product { Id = 2, Name = "Prod2", Description = "Prod2", Price = 15.99M };
                    break;
                case 3:
                    product = new Product { Id = 3, Name = "Prod3", Description = "Prod3", Price = 5M };
                    break;
            }

            return product;
        }
    }
}
