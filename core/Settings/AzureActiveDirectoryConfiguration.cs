using core.Settings.Contract;

namespace core.Settings
{
    public class AzureActiveDirectoryConfiguration : IAzureActiveDirectoryConfiguration
    {
        public string SubscriptionId { get; set; }
        public string TenantId { get; set; }
        public string Instance { get; set; }
        public string Authority => $"{Instance}{TenantId}";
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
        public string ClientOId { get; set; }
        public string Domain { get; set; }
        public string Scopes { get; set; }
    }
}
