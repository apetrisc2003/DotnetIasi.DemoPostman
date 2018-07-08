using System.Collections.Generic;

namespace DemoPostman.Models
{
    public class ShoppingCart
    {
        public string CartId { get; set; }
        public IEnumerable<Product> CartProducts { get; set; }
    }
}
