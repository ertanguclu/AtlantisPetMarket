using AutoMapper;
using BusinessLayer.Abstract;
using EntityLayer.DbContexts;
using EntityLayer.Models.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace AtlantisPetMarket.ViewComponents.FooterSocialMedia
{
    public class FooterSocialMediaList : ViewComponent
    {
        private readonly ISocialMediaManager<AppDbContext, SocialMedia, int> _socialManager;
        private readonly IMapper _mapper;
        public FooterSocialMediaList(ISocialMediaManager<AppDbContext, SocialMedia, int> socialManager, IMapper mapper)
        {
            _socialManager = socialManager;
            _mapper = mapper;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var socialMedias = await _socialManager.GetAllAsync(null);

            return View(socialMedias);
        }
    }
}
