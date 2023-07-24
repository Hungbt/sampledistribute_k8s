namespace core.Settings.Contract
{
    public interface IAzureActiveDirectoryConfiguration
    {
        public string SubscriptionId { get; set; }
        public string TenantId { get; set; }
        public string Instance { get; set; }
        public string Authority { get; }
        public string Domain { get; set; }
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
        public string ClientOId { get; set; }
        public string Scopes { get; set; }
    }
}
