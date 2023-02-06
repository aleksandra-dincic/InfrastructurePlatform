using Application.Model;

namespace Application.Services.Interface
{
    public interface IPlatformService
    {
        void CreatePlatform(PlatformModel platform);
        PlatformModel GetPlatformById(string platformId);
        List<PlatformModel> GetAllPlatforms();
        void DeletePlatform(string platformId);
        void UpdatePlatform(PlatformModel platform);
    }
}