using Application.Model;
using Application.Services.Interface;
using Domain.Entities;
using Persistence.Context;

namespace Application.Services.Behaviour
{
    public class PlatformService : IPlatformService
    {
        private readonly IPlatformRepository _repository;

        public PlatformService(IPlatformRepository repository)
        {
            _repository = repository;
        }

        public void CreatePlatform(PlatformModel platform)
        {
            _repository.CreatePlatform(new Platform
            {
                Id = $"platform:{Guid.NewGuid()}",
                Name = platform.Name,
                Description = platform.Description,
                Version = platform.Version,
                PictureUrl = platform.PictureUrl
            });
        }

        public void DeletePlatform(string platformId)
        {
            _repository.DeletePlatform(platformId);
        }

        public List<PlatformModel> GetAllPlatforms()
        {
            List<Platform> platforms = _repository.GetAllPlatforms();

            return platforms.Select(x => new PlatformModel
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                PictureUrl = x.PictureUrl,
                Version = x.Version
            })
            .ToList();
        }

        public PlatformModel GetPlatformById(string platformId)
        {
            Platform platform = _repository.GetPlatformById(platformId);

            return platform is null ? null :
                new PlatformModel
                {
                    Id = platform.Id,
                    Name = platform.Name,
                    Description = platform.Description,
                    Version = platform.Version,
                    PictureUrl = platform.PictureUrl
                };
        }

        public void UpdatePlatform(PlatformModel platform)
        {
            Platform convertedPlatform = new Platform
            {
                Id = platform.Id,
                Version = platform.Version,
                PictureUrl = platform.PictureUrl,
                Description = platform.Description,
                Name = platform.Name
            };

            _repository.UpdatePlatform(convertedPlatform);
        }
    }
}