using BusinessLayer.Abstract;
using EntityLayer.DbContexts;
using EntityLayer.Models.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace AtlantisPetMarket.ViewComponents.PetClothing
{


    public class PetClothingList : ViewComponent
    {
        private readonly IProductManager<AppDbContext, Product, int> _productManager;
        public PetClothingList(IProductManager<AppDbContext, Product, int> productManager)
        {
            _productManager = productManager;
        }
        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            var values = await _productManager.GetAllIncludeAsync(x => x.CategoryId == id, x => x.Category);
            return View(values);
        }
    }

}
