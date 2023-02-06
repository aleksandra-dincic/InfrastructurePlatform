using Domain.Entities;

namespace Persistence.Context
{
    public interface IPlatformRepository
    {
        void CreatePlatform(Platform platform);
        Platform GetPlatformById(string platformId);
        List<Platform> GetAllPlatforms();
        void DeletePlatform(string platformId);
        void UpdatePlatform(Platform convertedPlatform);
        List<Platform> GetPlatformsForIds(List<string> platformsIds);
    }
}