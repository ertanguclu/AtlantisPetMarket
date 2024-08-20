using AutoMapper;
using BusinessLayer.Abstract;
using BusinessLayer.Models.CartViewModel;
using EntityLayer.DbContexts;
using EntityLayer.Models.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace AtlantisPetMarket.ViewComponents.PetClothing
{


    public class PetClothingList : ViewComponent
    {
        private readonly IProductManager<AppDbContext, Product, int> _productManager;
        private readonly IMapper _mapper;
        public PetClothingList(IProductManager<AppDbContext, Product, int> productManager, IMapper mapper)
        {
            _productManager = productManager;
            _mapper = mapper;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _productManager.GetProductsByCategoryAsync(x => x.Category.CategoryName.ToLower() == "kıyafet", x => x.Category);
            var random = new Random();
            var randomProducts = values.OrderBy(x => random.Next()).Take(4).ToList();
            var model = _mapper.Map<List<ProductCartVM>>(randomProducts);
            return View(model);

        }
    }
}
