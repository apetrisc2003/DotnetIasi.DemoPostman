using DemoPostman.Interfaces;
using DemoPostman.Models;
using Microsoft.AspNetCore.Mvc;

namespace DemoPostman.Web.Controllers
{
    [Route("api/[controller]")]
    public class ShoppingCartController : ControllerBase
    {
        public readonly IShoppingCartService shoppingCartService;

        public ShoppingCartController(IShoppingCartService shoppingCartService)
        {
            this.shoppingCartService = shoppingCartService;
        }

        [HttpPost]
        public IActionResult Post([FromBody]ShoppingCart shoppingCart)
        {
            var totalResult = shoppingCartService.GetShoppingCartDetails(shoppingCart);

            return Ok(totalResult);
        }
    }
}
