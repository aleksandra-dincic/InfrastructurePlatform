using Application.Model;

namespace Application.Services.Interface
{
    public interface ISystemService
    {
        void CreateSystem(SystemModel system);
        SystemModel GetSystemById(string systemId);
        SystemAndPlatformsModel GetAllSystems();
        void DeleteSystem(string systemId);
        void AddServices(string systemId, List<string> platformsIds);
        void UpdateSystem(SystemModel system);
    }
}