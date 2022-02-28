using System;
using ChristmasLib.Config;
using ChristmasLib.Utils;

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
        
            var plugincfg = new PluginConfig();
            ChristmasConfig cfg = new ChristmasConfig();
            plugincfg = cfg.Load(ConfigName, plugincfg);
            Debug = ConfigUtils.ParseBool(plugincfg.Debug);
            CustomStartScreen = ConfigUtils.ParseBool(plugincfg.CustomStartScreen);
            LogDownloads = ConfigUtils.ParseBool(plugincfg.LogDownloads);
            ChristmasUI = ConfigUtils.ParseBool(plugincfg.ChristmasUI);
        }
                
    }
}