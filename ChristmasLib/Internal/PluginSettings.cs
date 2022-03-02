using ChristmasLib.Config;

namespace ChristmasLib.Internal
{
    
    public class PluginConfig
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
        
            var pluginCfg = new PluginConfig();
            ChristmasConfig cfg = new ChristmasConfig(ConfigName);
            pluginCfg = cfg.Load(ConfigName, pluginCfg);
            Debug = ConfigUtils.ParseBool(pluginCfg.Debug);
            CustomStartScreen = ConfigUtils.ParseBool(pluginCfg.CustomStartScreen);
            LogDownloads = ConfigUtils.ParseBool(pluginCfg.LogDownloads);
            ChristmasUI = ConfigUtils.ParseBool(pluginCfg.ChristmasUI);
        }
                
    }
}