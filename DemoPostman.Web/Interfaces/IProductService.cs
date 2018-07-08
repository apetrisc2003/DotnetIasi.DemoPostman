using System.Collections.Generic;
using DemoPostman.Models;

namespace DemoPostman.Interfaces
{
    public interface IProductService
    {
        List<Product> GetProducts();
        Product GetProductDetails(int productId);
    }
}
