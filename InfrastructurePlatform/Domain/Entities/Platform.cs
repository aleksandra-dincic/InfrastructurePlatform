using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Platform
    {
        public string Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;
        public string Version { get; set; }
        public string Description { get; set; }
        public string PictureUrl { get; set; }
    }
}
