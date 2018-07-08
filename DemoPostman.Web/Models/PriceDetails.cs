using System.Collections.Generic;

namespace DemoPostman.Models
{
    public class PriceDetails
    {
        public decimal TotalPrice { get; set; }
        public decimal DiscountedPrice { get; set; }
        public decimal RebateValue { get; set; }
        public IEnumerable<Product> SelectedProducts { get; set; }
    }
}
