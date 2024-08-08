using AutoMapper;
using BusinessLayer.Models.CartItemVM;
using BusinessLayer.Models.CartViewModel;
using BusinessLayer.Models.CategoryVM;
using BusinessLayer.Models.ProductVM;
using EntityLayer.Models.Concrete;

namespace BusinessLayer.AutoMapperConfig
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<Product, ProductInsertVM>();
            CreateMap<ProductInsertVM, Product>();
            CreateMap<Product, ProductUpdateVM>().ReverseMap();
            CreateMap<Product, ProductListVM>().ReverseMap();

            CreateMap<Category, CategoryUpdateVM>().ReverseMap();
            CreateMap<Category, CategoryInsertVM>().ReverseMap();

            CreateMap<CartItem, CartItemViewModel>().ReverseMap();

            CreateMap<Cart, CartVM>().ReverseMap();

            CreateMap<ProductListVM, CartItemViewModel>();


        }
    }
}
