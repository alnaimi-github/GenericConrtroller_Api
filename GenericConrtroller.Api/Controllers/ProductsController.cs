using GenericController.Api.Repositories.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GenericController.Api.Controllers
{
    [Route("api/[controller]")]
    public class ProductsController : BaseController<Product>
    {
        private readonly IProductRepository _productRepository;

        public ProductsController(IProductRepository productRepository) : base(productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet("priceRange")]
        public async Task<IActionResult> GetProductsByPriceRange(decimal minPrice, decimal maxPrice)
        {
            var products =await _productRepository.GetProductsByPriceRangeAsync(minPrice, maxPrice);
            return Ok(products);
        }
    }
}
