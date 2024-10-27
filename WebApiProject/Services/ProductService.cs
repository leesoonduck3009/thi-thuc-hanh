using AutoMapper;
using TestWebApplication.Dtos.Product;
using TestWebApplication.Entities;
using TestWebApplication.Repositories.Interface;
using TestWebApplication.Services.Interface;

namespace TestWebApplication.Services
{
    public class ProductService : IProductService
    {
        private readonly IMapper _mapper;
        private readonly IBaseRepository<Product> _productRepository;
        public ProductService(IMapper mapper, IBaseRepository<Product> productRepository)
        {
            _mapper = mapper;
            _productRepository = productRepository;
        }

        public async Task<List<ProductDto>> GetAllProductsAsync(string searchText, int pageIndex, int pageSize)
        {
            var paginationResponse = await _productRepository.GetAllAsync(p => p.Name.Contains(searchText), p => p.OrderByDescending(p => p.Name), pageIndex, pageSize);
            return _mapper.Map<List<ProductDto>>(paginationResponse.Items);
        }

        public async Task<ProductDto> GetProductByIdAsync(Guid productId)
        {
            var proudct = await _productRepository.GetFirstOrDefaultAsync(p => p.Id == productId);
            if (proudct == null)
            {
                throw new Exception("Product not found");
            }
            return _mapper.Map<ProductDto>(proudct);
        }

        public async Task<ProductDto> CreateProductAsync(CreateProductRequestDto request)
        {
            Product product = _mapper.Map<Product>(request);
            await _productRepository.AddAsync(product);
            return _mapper.Map<ProductDto>(product);
        }

        public async Task<ProductDto> DeleteProductAsync(Guid productId)
        {
            Product product = await _productRepository.GetFirstOrDefaultAsync(p => p.Id == productId);
            if (product == null)
            {
                throw new Exception("Product not found");
            }
            await _productRepository.DeleteAsync(product);
            return _mapper.Map<ProductDto>(product);
        }

        public async Task<ProductDto> UpdateProductAsync(Guid productId, ProductDto product)
        {
            Product productResponse = await _productRepository.GetFirstOrDefaultAsync(_ => _.Id == productId);
            if (productResponse == null)
            {
                throw new Exception("Product not found");
            }
            _mapper.Map(product, productResponse);
            await _productRepository.UpdateAsync(productResponse);
            return product;
        }
    }
}
