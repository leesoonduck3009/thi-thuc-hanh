using AutoMapper;
using TestWebApplication.Dtos.Product;
using TestWebApplication.Entities;

namespace TestWebApplication.Mapping
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<CreateProductRequestDto, Product>();
            CreateMap<Product, ProductDto>();
            CreateMap<ProductDto, Product>();
        }
    }
}
