using Microsoft.AspNetCore.Mvc;

namespace AtlantisPetMarket.Controllers
{

    public class PetFoodiesController : Controller
    {

        public async Task<IActionResult> LoadFoods(string category)
        {
            if (category == "Kedi Maması")
            {
                return ViewComponent("CatFoodsList");
            }
            else if (category == "Köpek Maması")
            {
                return ViewComponent("DogFoodsList");
            }
            else if (category == "Kuş Yemi")
            {
                return ViewComponent("BirdFoodsList");
            }
            else if (category == "Balık Yemi")
            {
                return ViewComponent("FishFoodsList");
            }
            else if (category == "Kemirgen Yemi")
            {
                return ViewComponent("RodentFoodsList");
            }
            else
            {
                return ViewComponent("GetAllFoodsList");
            }
        }
    }
}
