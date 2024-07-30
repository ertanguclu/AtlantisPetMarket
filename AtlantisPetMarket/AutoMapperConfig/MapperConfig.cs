using AtlantisPetMarket.Models.CategoryVM;
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

            CreateMap<Category, CategoryUpdateVM>()
            .ForMember(dest => dest.CurrentPhotoPath, opt => opt.MapFrom(src => src.CategoryPhotoPath)) // Mevcut resim yolunu eşleştirme
            .ForMember(dest => dest.CategoryPhotoPath, opt => opt.Ignore()); // IFormFile eşleştirmesini atla
            CreateMap<CategoryInsertVM, Category>();
            CreateMap<Category, CategoryInsertVM>();


        }
    }
}
