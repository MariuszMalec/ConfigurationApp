using System.ComponentModel.DataAnnotations;

namespace ConfigurationApp.Configuration
{
    public class ServiceConfiguration
    {
        public const string SectionName = "ServiceConfiguration";

        public string ContactEmail { get; set; }
        [Required]
        public string ApiKey { get; set; }
    }
}
