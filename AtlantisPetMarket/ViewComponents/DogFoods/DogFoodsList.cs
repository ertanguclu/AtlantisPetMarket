using AutoMapper;
using BusinessLayer.Abstract;
using BusinessLayer.Models.ProductVM;
using EntityLayer.DbContexts;
using EntityLayer.Models.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace AtlantisPetMarket.ViewComponents.DogFoods
{
    public class DogFoodsList : ViewComponent
    {
        private readonly IProductManager<AppDbContext, Product, int> _productManager;
        private readonly IMapper _mapper;
        public DogFoodsList(IProductManager<AppDbContext, Product, int> productManager, IMapper mapper)
        {
            _productManager = productManager;
            _mapper = mapper;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            string categoryName = "Köpek Maması";
            var products = await _productManager.GetProductsByCategoryAsync(p => p.Category.CategoryName == categoryName, p => p.Category);
            var random = new Random();
            var randomProducts = products.OrderBy(x => random.Next()).Take(8).ToList();
            var model = _mapper.Map<List<ProductListVM>>(randomProducts);
            return View(model);
        }
    }
}
