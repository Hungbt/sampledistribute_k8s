namespace core.Settings.Contract
{
    public interface IAzureCognitiveSearchConfiguration
    {
        public string ServiceName { get; set; }
        public string ApiKey { get; set; }
        public string IndexName { get; set; }
        public string SemanticConfigurationName { get; set; }
    }
}
