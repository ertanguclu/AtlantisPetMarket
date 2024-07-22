using AtlantisPetMarket.Models;
using AutoMapper;
using EntityLayer.Models.Concrete;

namespace AtlantisPetMarket.AutoMapperConfig
{
    public class ProductMapperConfig : Profile
    {
        public ProductMapperConfig()
        {
            CreateMap<ProductInsertVM, Product>();
            CreateMap<Product, ProductInsertVM>();

        }

    }
}
