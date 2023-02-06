using System.Text.Json;
using Domain.Entities;
using StackExchange.Redis;

namespace Persistence.Context.Repositories.System
{
    public class SystemRepository : ISystemRepository
    {
        private readonly IConnectionMultiplexer _redis;

        public SystemRepository(IConnectionMultiplexer connection)
        {
            _redis = connection;
        }

        public void AddServices(string systemId, List<Platform> platforms)
        {
            var database = _redis.GetDatabase();

            var system = GetSystemById(systemId);

            if (system != null)
            {
                system.Platforms = platforms;

                var jsonSystem = JsonSerializer.Serialize(system);

                database.HashSet("hashsystem", new HashEntry[] { new HashEntry(system.Id, jsonSystem) });
            }
        }

        public void CreateSystem(Domain.Entities.System system)
        {
            if (system is not null)
            {
                var database = _redis.GetDatabase();

                var jsonSystem = JsonSerializer.Serialize(system);

                database.HashSet("hashsystem", new HashEntry[] { new HashEntry(system.Id, jsonSystem) });
            }
        }

        public void DeleteSystem(string systemId)
        {
            var database = _redis.GetDatabase();

            database.HashDelete("hashsystem", systemId);
        }

        public List<Domain.Entities.System> GetAllSystems()
        {
            var database = _redis.GetDatabase();

            var completeHash = database.HashGetAll("hashsystem");

            if (completeHash.Length == 0) return new List<Domain.Entities.System>();

            var systems = Array.ConvertAll(completeHash, val => JsonSerializer.Deserialize<Domain.Entities.System>(val.Value)).ToList();

            return systems;
        }

        public Domain.Entities.System GetSystemById(string systemId)
        {
            var database = _redis.GetDatabase();

            var system = database.HashGet("hashsystem", systemId);

            if (!string.IsNullOrEmpty(system))
            {
                var jsonSystem = JsonSerializer.Deserialize<Domain.Entities.System>(system);

                return jsonSystem;
            }

            return null;
        }

        public List<Platform> GetSystemPlatforms(string id)
        {
            var system = GetSystemById(id);

            return system != null ? system.Platforms : new List<Platform>();
        }

        public void UpdateSystem(Domain.Entities.System convertedSystem)
        {
            if (convertedSystem is not null)
            {
                var database = _redis.GetDatabase();

                var jsonSystem = JsonSerializer.Serialize(convertedSystem);

                database.HashSet("hashsystem", new HashEntry[] { new HashEntry(convertedSystem.Id, jsonSystem) });
            }
        }
    }
}