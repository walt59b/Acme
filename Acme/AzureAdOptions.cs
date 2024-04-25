using System.ComponentModel.DataAnnotations;

namespace API
{
    public class AzureAdOptions
    {
        public const string SectionName = "Authentication:AzureAd";

        [Required]
        public string? Instance { get; set; }

        [Required]
        public string? TenantId { get; set; }

        [Required]
        public string Audience { get; set; } = string.Empty;

        [Required]
        public string? Issuer { get; set; }

        public string Authority => $"{Instance}/{TenantId}/v2.0";

        public string? ClientSecret { get; set; }
    }
}
