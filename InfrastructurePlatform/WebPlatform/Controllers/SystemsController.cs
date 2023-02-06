using Application.Model;
using Application.Services.Behaviour;
using Application.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace WebPlatform.Controllers
{
    public class SystemsController : Controller
    {
        private readonly ISystemService _systemService;

        public SystemsController(ISystemService systemService)
        {
            _systemService = systemService;
        }

        public IActionResult Index()
        {
            var allSystem = _systemService.GetAllSystems();

            return View(allSystem);
        }

        public IActionResult System(string id)
        {
            var system = _systemService.GetSystemById(id);

            return View(system);
        }

        public void CreateSystem(SystemModel system)
        {
            _systemService.CreateSystem(system);
        }

        public void AddServices(SystemModel system)
        {
            _systemService.AddServices(system.Id, system.PlatformsIds);
        }

        public void UpdateSystem(SystemModel system)
        {
            _systemService.UpdateSystem(system);
        }

        public void DeleteSystem(string systemId)
        {
            _systemService.DeleteSystem(systemId);
        }
    }
}
