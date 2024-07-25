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
            CreateMap<ProductUpdateVM, Product>();
            CreateMap<Product, ProductUpdateVM>();


            //CreateMap<Product, ProductInsertVM>().ReverseMap();
            //CreateMap<Product, ProductUpdateVM>().ReverseMap();
            //CreateMap<Product, ProductListVM>().ReverseMap();
        }
    }
}
