using AutoMapper;
using BusinessLayer.Abstract;
using BusinessLayer.Models.CartViewModel;
using EntityLayer.DbContexts;
using EntityLayer.Models.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AtlantisPetMarket.ViewComponents.ProductOfTheMonth
{

    public class ProductOfTheMonthList : ViewComponent
    {
        private readonly IProductManager<AppDbContext, Product, int> _productManager;
        private readonly IMapper _mapper;
        public ProductOfTheMonthList(IProductManager<AppDbContext, Product, int> productManager, IMapper mapper)
        {
            _productManager = productManager;
            _mapper = mapper;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var productsQuery = _productManager.GetAllInclude(
                x => x.IsProductOfTheMonth == true,
                x => x.Category);
            var products = await productsQuery.ToListAsync();
            var productVM = _mapper.Map<IEnumerable<ProductCartVM>>(products);
            return View(productVM);
        }
    }
}
