using ChristmasLib.Utils;

namespace ChristmasLib.Internal
{
    
    public class Config
    {
        public string Debug = "false";
        public string CustomStartScreen = "true";
        public string LogDownloads = "true";
        public string ChristmasUI = "true";
    }


    
    internal static class PluginSettings
    {
        private static readonly string ConfigName = "ChristmasLibConfig.json";

        public static bool Debug,CustomStartScreen,LogDownloads,ChristmasUI;
        public static void InitSettings(){
        
            var config = new Config();
            
            config = ConfigUtils.Load(ConfigName, config);

            Debug = ConfigUtils.Parse<bool>(config.Debug);
            CustomStartScreen = ConfigUtils.Parse<bool>(config.CustomStartScreen);
            LogDownloads = ConfigUtils.Parse<bool>(config.LogDownloads);
            ChristmasUI = ConfigUtils.Parse<bool>(config.ChristmasUI);
        }
                
    }
}