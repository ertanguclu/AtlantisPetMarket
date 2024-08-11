using BusinessLayer.Models.CartItemVM;
using BusinessLayer.Models.CartViewModel;
using BusinessLayer.Models.CategoryVM;
using BusinessLayer.Models.ProductVM;
using AutoMapper;
using EntityLayer.Models.Concrete;

namespace BusinessLayer.AutoMapperConfig
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<ProductInsertVM, Product>();
            CreateMap<Product, ProductInsertVM>();

            CreateMap<ProductUpdateVM, Product>();
            CreateMap<Product, ProductUpdateVM>();
            CreateMap<Product, ProductListVM>();

            CreateMap<Product, ProductListVM>();
            CreateMap<CartVM, ProductListVM>().ReverseMap();
            CreateMap<Cart, ProductCartVM>().ReverseMap();
            CreateMap<Product, ProductCartVM>().ReverseMap();


            CreateMap<CategoryUpdateVM, Category>();
            CreateMap<Category, CategoryUpdateVM>();

            CreateMap<CategoryInsertVM, Category>();
            CreateMap<Category, CategoryInsertVM>();
            CreateMap<CartItem, CartItemViewModel>();
            CreateMap<CartItemViewModel, CartItem>();
            CreateMap<CartVM, Cart>();
            CreateMap<Cart, CartVM>();
            CreateMap<ProductListVM, CartItemViewModel>();


        }
    }
}
