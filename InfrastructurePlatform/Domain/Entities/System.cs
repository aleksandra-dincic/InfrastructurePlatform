namespace Domain.Entities
{
    public class System
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Version { get; set; }
        public string Description { get; set; }
        public string OperatingSystem { get; set; }
        public List<Platform> Platforms { get; set; }
    }
}
