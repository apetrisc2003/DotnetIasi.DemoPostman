using DemoPostman.Interfaces;
using DemoPostman.Web.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DemoPostman.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        public readonly IProductService productService;

        public ProductController(IProductService productService, IShoppingCartService shoppingCartService)
        {
            this.productService = productService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var products = productService.GetProducts();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var product = productService.GetProductDetails(id);

            return Ok(product);
        }


    }
}
