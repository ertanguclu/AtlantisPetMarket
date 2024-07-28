using AtlantisPetMarket.Models.CategortVm;
using AtlantisPetMarket.Models.ProductVM;
using AutoMapper;
using EntityLayer.Models.Concrete;

namespace AtlantisPetMarket.AutoMapperConfig
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<ProductInsertVM, Product>();
            CreateMap<Product, ProductInsertVM>();
            CreateMap<ProductUpdateVM, Product>();
            CreateMap<Product, ProductUpdateVM>();
            CreateMap<CategoryUpdateVM, Category>();
            CreateMap<Category, CategoryUpdateVM>();

        }
    }
}
