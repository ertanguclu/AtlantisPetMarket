using AtlantisPetMarket.Models;
using AutoMapper;
using EntityLayer.Models.Concrete;

namespace AtlantisPetMarket.AutoMapperConfig
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<ProductInsertVM, Product>();
            //CreateMap<Product, ProductInsertVM>().ReverseMap();
            //CreateMap<Product, ProductUpdateVM>().ReverseMap();
            //CreateMap<Product, ProductListVM>().ReverseMap();
        }
    }
}
