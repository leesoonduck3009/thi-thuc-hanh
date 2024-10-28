using TestWebApplication.Dtos.Product;

namespace TestWebApplication.Services.Interface
{
    public interface IProductService
    {
        Task<List<ProductDto>> GetAllProductsAsync(string searchText, string Category, int pageIndex, int pageSize);
        Task<ProductDto> GetProductByIdAsync(Guid productId);
        Task<ProductDto> CreateProductAsync(CreateProductRequestDto request);
        Task<ProductDto> UpdateProductAsync(Guid productId, ProductDto product);
        Task<ProductDto> DeleteProductAsync(Guid productId);

    }
}
