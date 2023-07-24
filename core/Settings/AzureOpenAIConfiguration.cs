using core.Settings.Contract;

namespace core.Settings
{
    public class AzureOpenAIConfiguration : IAzureOpenAIConfiguration
    {
        public string EndPoint { get; set; }
        public string Key { get; set; }
        public string GPTDeployment { get; set; }
        public string ChatGPTDeployment { get; set; }
    }
}
