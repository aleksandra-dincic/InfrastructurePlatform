using Domain.Entities;

namespace Persistence.Context
{
    public interface ISystemRepository
    {
        void CreateSystem(Domain.Entities.System system);
        Domain.Entities.System GetSystemById(string systemId);
        List<Domain.Entities.System> GetAllSystems();
        void DeleteSystem(string systemId);
        void AddServices(string systemId, List<Platform> platformsIds);
        List<Platform> GetSystemPlatforms(string id);
        void UpdateSystem(Domain.Entities.System convertedSystem);
    }
}