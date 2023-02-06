using System;
using Application.Model;
using Application.Services.Interface;
using Domain.Entities;
using Persistence.Context;

namespace Application.Services.Behaviour
{
    public class SystemService : ISystemService
    {
        private readonly ISystemRepository _repository;
        private readonly IPlatformRepository _platformRepository;

        public SystemService(ISystemRepository repository, IPlatformRepository platformRepository)
        {
            _repository = repository;
            _platformRepository = platformRepository;
        }

        public void AddServices(string systemId, List<string> platformsIds)
        {
            List<Platform> platforms = _platformRepository.GetPlatformsForIds(platformsIds);

            _repository.AddServices(systemId, platforms);
        }

        public void CreateSystem(SystemModel system)
        {
            List<Platform> platforms = _platformRepository.GetPlatformsForIds(system.PlatformsIds);

            _repository.CreateSystem(new Domain.Entities.System
            {
                Id = $"system:{Guid.NewGuid()}",
                Name = system.Name,
                OperatingSystem = system.OperatingSystem,
                Version = system.Version,
                Description = system.Description,
                Platforms = platforms
            });
        }

        public void DeleteSystem(string systemId)
        {
            _repository.DeleteSystem(systemId);
        }

        public SystemAndPlatformsModel GetAllSystems()
        {
            List<Domain.Entities.System> systems = _repository.GetAllSystems();
            List<Platform> platforms = _platformRepository.GetAllPlatforms();

            var allSystems = systems.Select(x => new SystemModel
            {
                Id = x.Id,
                Name = x.Name,
                Version = x.Version,
                Description = x.Description,

                OperatingSystem = x.OperatingSystem
            })
            .ToList();

            SystemAndPlatformsModel systemAndPlatforms = new SystemAndPlatformsModel();

            systemAndPlatforms.Systems = allSystems;
            systemAndPlatforms.AllPlatforms = platforms.Select(x => new PlatformModel
            {
                Id = x.Id,
                Name = x.Name
            }).ToList();

            return systemAndPlatforms;
        }

        public SystemModel GetSystemById(string systemId)
        {
            Domain.Entities.System system = _repository.GetSystemById(systemId);
            List<Platform> platforms = _platformRepository.GetAllPlatforms();

            return system is null ? null : new SystemModel
            {
                Id = system.Id,
                Name = system.Name,
                OperatingSystem = system.OperatingSystem,
                Version = system.Version,
                AllPlatforms = platforms.Select(x => new PlatformModel
                {
                    Id = x.Id,
                    Name = x.Name
                }).ToList(),
                Platforms = system.Platforms.Select(x => new PlatformModel
                {
                    Id = x.Id,
                    Name = x.Name
                }).ToList(),
                Description = system.Description
            };
        }

        public void UpdateSystem(SystemModel system)
        {
            List<Platform> platforms = _repository.GetSystemPlatforms(system.Id);

            Domain.Entities.System convertedSystem = new Domain.Entities.System
            {
                Id = system.Id,
                Version = system.Version,
                Description = system.Description,
                Name = system.Name,
                OperatingSystem = system.OperatingSystem,
                Platforms = platforms
            };

            _repository.UpdateSystem(convertedSystem);
        }
    }
}