using AtlantisPetMarket.Models.ProductVM;
using AutoMapper;
using BusinessLayer.Abstract;
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
            var values = await _productManager.GetAllAsync(x => x.CategoryId == 5);
            if (values != null)
            {
                var random = new Random();
                var randomProducts = values.OrderBy(x => random.Next()).Take(4).ToList();
                var model = _mapper.Map<List<ProductListVM>>(randomProducts);
                return View(model);
            }
            else
            {
                return View(new List<ProductListVM>());
            }
        }
    }
}
