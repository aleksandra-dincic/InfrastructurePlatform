using System;
using System.Text.Json;
using Domain.Entities;
using StackExchange.Redis;

namespace Persistence.Context
{
    public class PlatformRepository : IPlatformRepository
    {
        private readonly IConnectionMultiplexer _redis;

        public PlatformRepository(IConnectionMultiplexer connection)
        {
            _redis = connection;
        }

        public void CreatePlatform(Platform platform)
        {
            if (platform is not null)
            {
                var database = _redis.GetDatabase();

                var jsonPlatform = JsonSerializer.Serialize(platform);

                database.HashSet("hashplatform", new HashEntry[] { new HashEntry(platform.Id, jsonPlatform) });
            }
        }

        public void DeletePlatform(string platformId)
        {
            var database = _redis.GetDatabase();

            database.HashDelete("hashplatform", platformId);
        }

        public List<Platform> GetAllPlatforms()
        {
            var database = _redis.GetDatabase();

            var completeHash = database.HashGetAll("hashplatform");

            if (completeHash.Length == 0) return new List<Platform>();

            var platforms = Array.ConvertAll(completeHash, val => JsonSerializer.Deserialize<Platform>(val.Value)).ToList();

            return platforms;
        }

        public Platform GetPlatformById(string platformId)
        {
            var database = _redis.GetDatabase();

            var platform = database.HashGet("hashplatform", platformId);

            if (!string.IsNullOrEmpty(platform))
            {
                return JsonSerializer.Deserialize<Platform>(platform);
            }

            return null;
        }

        public List<Platform> GetPlatformsForIds(List<string> platformsIds)
        {
            var database = _redis.GetDatabase();

            List<Platform> platforms = new List<Platform>();
            foreach (var platformId in platformsIds)
            {
                var platformValue = database.HashGet("hashplatform", platformId);

                if (!string.IsNullOrEmpty(platformValue))
                {
                    var platform = JsonSerializer.Deserialize<Platform>(platformValue);

                    platforms.Add(platform);
                }
            }

            return platforms;
        }

        public void UpdatePlatform(Platform convertedPlatform)
        {
            if (convertedPlatform is not null)
            {
                var database = _redis.GetDatabase();

                var jsonPlatform = JsonSerializer.Serialize(convertedPlatform);

                database.HashSet("hashplatform", new HashEntry[] { new HashEntry(convertedPlatform.Id, jsonPlatform) });
            }
        }
    }
}
