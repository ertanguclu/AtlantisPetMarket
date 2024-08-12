using AutoMapper;
using BusinessLayer.Abstract;
using BusinessLayer.Models.CartItemVM;
using EntityLayer.DbContexts;
using EntityLayer.Models.Concrete;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AtlantisPetMarket.Controllers
{
    public class CartItemController : Controller
    {
        private readonly ICartItemManager<AppDbContext, CartItem, int> _cartItemManager;
        private readonly IMapper _mapper;
        private readonly IValidator<CartItemViewModel> _validator;

        public CartItemController(ICartItemManager<AppDbContext, CartItem, int> cartItemManager, IMapper mapper, IValidator<CartItemViewModel> validator)
        {
            _cartItemManager = cartItemManager;
            _mapper = mapper;
            _validator = validator;
        }

        

        

       
    }
}
