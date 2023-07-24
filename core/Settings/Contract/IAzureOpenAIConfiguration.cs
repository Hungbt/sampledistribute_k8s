namespace core.Settings.Contract
{
    public interface IAzureOpenAIConfiguration
    {
        public string EndPoint { get; set; }
        public string Key { get; set; }
        public string GPTDeployment { get; set; }
        public string ChatGPTDeployment { get; set; }
    }
}
