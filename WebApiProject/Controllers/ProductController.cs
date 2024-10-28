using Microsoft.AspNetCore.Mvc;
using TestWebApplication.Dtos;
using TestWebApplication.Dtos.Product;
using TestWebApplication.Services.Interface;
namespace TestWebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAllProductsAsync([FromQuery] string searchText = "", [FromQuery] string filter = "", [FromQuery] int pageIndex = 0, [FromQuery] int pageSize = 30)
        {
            return Ok(ApiResult<List<ProductDto>>.Success(await _productService.GetAllProductsAsync(searchText, filter, pageIndex, pageSize)));
        }
        [HttpGet]
        [Route("{productId}")]
        public async Task<IActionResult> GetProductByIdAsync(Guid productId)
        {
            return Ok(ApiResult<ProductDto>.Success(await _productService.GetProductByIdAsync(productId)));
        }
        [HttpPost]
        [Route("")]
        public async Task<IActionResult> CreateProductAsync([FromBody] CreateProductRequestDto request)
        {
            return Ok(ApiResult<ProductDto>.Success(await _productService.CreateProductAsync(request)));
        }
        [HttpPut]
        [Route("{productId}")]
        public async Task<IActionResult> CreateProductAsync(Guid productId, [FromBody] ProductDto request)
        {
            return Ok(ApiResult<ProductDto>.Success(await _productService.UpdateProductAsync(productId, request)));
        }
        [HttpDelete]
        [Route("{productId}")]
        public async Task<IActionResult> DeleteProductAsync(Guid productId)
        {
            return Ok(ApiResult<ProductDto>.Success(await _productService.DeleteProductAsync(productId)));
        }
    }
}