using AutoMapper;
using BusinessLayer.Abstract;
using BusinessLayer.Models.CartViewModel;
using EntityLayer.DbContexts;
using EntityLayer.Models.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace AtlantisPetMarket.ViewComponents.BirdFoods
{
    public class BirdFoodsList : ViewComponent
    {
        private readonly IProductManager<AppDbContext, Product, int> _productManager;
        private readonly IMapper _mapper;
        public BirdFoodsList(IProductManager<AppDbContext, Product, int> productManager, IMapper mapper)
        {
            _productManager = productManager;
            _mapper = mapper;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            // Kuş kategorisine ve 'yem' içeren ürünlere göre filtreleme
            var products = await _productManager.GetProductsByCategoryAsync(
                p => p.ParentCategory.ParentCategoryName.ToLower() == "kuş" && p.Category.CategoryName.ToLower().Contains("yemler"),
                p => p.ParentCategory,
                p => p.Category
            );

            // Rastgele seçme ve ilk 8 ürünü alma
            var random = new Random();
            var randomProducts = products.OrderBy(x => random.Next()).Take(8).ToList();

            // Modeli oluşturma
            var model = _mapper.Map<List<ProductCartVM>>(randomProducts);

            return View(model);
        }
    }
}
