using AutoMapper;
using BusinessLayer.Models.CartItemVM;
using BusinessLayer.Models.CartViewModel;
using BusinessLayer.Models.CategoryVM;
using BusinessLayer.Models.ContactVM;
using BusinessLayer.Models.ProductVM;
using BusinessLayer.Models.SocialMediaVM;
using EntityLayer.Models.Concrete;

namespace BusinessLayer.AutoMapperConfig
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<Product, ProductInsertVM>().ReverseMap();

            CreateMap<Product, ProductUpdateVM>().ReverseMap();
            CreateMap<Product, ProductListVM>();

            CreateMap<Product, ProductListVM>().ReverseMap();
            CreateMap<CartVM, ProductListVM>().ReverseMap();
            CreateMap<Cart, ProductCartVM>().ReverseMap();
            CreateMap<Product, ProductCartVM>().ReverseMap();
            CreateMap<CartItem, ProductCartVM>().ReverseMap();

            CreateMap<Category, CategoryUpdateVM>().ReverseMap();

            CreateMap<Category, CategoryInsertVM>().ReverseMap();
            CreateMap<CartItem, CartItemViewModel>().ReverseMap();

            CreateMap<Cart, CartVM>().ReverseMap();
            CreateMap<ProductListVM, CartItemViewModel>();

            CreateMap<Contact, ContactListVM>();
            CreateMap<Contact, ContactInsertVM>().ReverseMap();
            CreateMap<Contact, ContactUpdateVM>().ReverseMap();

            CreateMap<SocialMedia, SocialMediaListVM>();
            CreateMap<SocialMedia, SocialMediaInsertVM>().ReverseMap();
            CreateMap<SocialMedia, SocialMediaUpdateVM>().ReverseMap();


        }
    }
}
