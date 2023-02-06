namespace Application.Model
{
    public class SystemModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Version { get; set; }
        public string OperatingSystem { get; set; }
        public string Description { get; set; }
        public List<PlatformModel> Platforms { get; set; }
        public List<PlatformModel> AllPlatforms { get; set; }
        public List<string> PlatformsIds { get; set; }

    }

    public class SystemAndPlatformsModel
    {
        public List<SystemModel> Systems { get; set; }
        public List<PlatformModel> AllPlatforms { get; set; }
    }
}
