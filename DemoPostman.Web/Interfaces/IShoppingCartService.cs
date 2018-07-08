using DemoPostman.Models;

namespace DemoPostman.Interfaces
{
    public interface IShoppingCartService
    {
        PriceDetails GetShoppingCartDetails(ShoppingCart shoppingCart);
    }
}
