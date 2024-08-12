using BusinessLayer.Abstract;
using EntityLayer.DbContexts;
using EntityLayer.Models.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace AtlantisPetMarket.Controllers
{
    public class SocialMediaController : Controller
    {
        private readonly ISocialMediaManager<AppDbContext, SocialMedia, int> _socialMediaManager;
        public SocialMediaController(ISocialMediaManager<AppDbContext, SocialMedia, int> socialMediaManager)
        {
            _socialMediaManager = socialMediaManager;

        }
        public async Task<ActionResult<IEnumerable<SocialMedia>>> Index()
        {
            var socialMedias = await _socialMediaManager.GetAllAsync(null);
            return View(socialMedias);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            SocialMedia socialMedia = new SocialMedia();

            return View(socialMedia);

        }
        [HttpPost]
        public async Task<IActionResult> Create(SocialMedia socialMedia)
        {

            await _socialMediaManager.AddAsync(socialMedia);
            return RedirectToAction("Index");

        }
        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var socialMedia = await _socialMediaManager.FindAsync(id);
            ViewBag.sIcon = socialMedia.Icon;
            return View(socialMedia);
        }
        [HttpPost]
        public async Task<IActionResult> Update(SocialMedia socialMedia)
        {
            await _socialMediaManager.UpdateAsync(socialMedia);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var socialMedia = await _socialMediaManager.FindAsync(id);
            await _socialMediaManager.DeleteAsync(socialMedia);
            return RedirectToAction("Index");
        }

    }
}
