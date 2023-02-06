using Application.Model;
using Application.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace WebPlatform.Controllers
{
    public class PlatformsController : Controller
    {
        private readonly IPlatformService _platformService;

        public PlatformsController(IPlatformService platformService)
        {
            _platformService = platformService;
        }

        public IActionResult Index()
        {
            var allPlaftorms = _platformService.GetAllPlatforms();

            return View(allPlaftorms);
        }

        public IActionResult Platform(string id)
        {
            var platform = _platformService.GetPlatformById(id);

            return View(platform);
        }

        public void CreatePlatform(PlatformModel platform)
        {
            _platformService.CreatePlatform(platform);
        }

        public void UpdatePlatform(PlatformModel platform)
        {
            _platformService.UpdatePlatform(platform);
        }

        public void DeletePlatform(string platformId)
        {
            _platformService.DeletePlatform(platformId);
        }

        public List<PlatformModel> GetAllPlatforms()
        {
            return _platformService.GetAllPlatforms();
        }

        public PlatformModel GetPlatformById(string platformId)
        {
            return _platformService.GetPlatformById(platformId);
        }
    }
}
