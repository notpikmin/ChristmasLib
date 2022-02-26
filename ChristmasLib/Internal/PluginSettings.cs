using System;
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
            Debug = ConfigUtils.ParseBool(config.Debug);
            CustomStartScreen = ConfigUtils.ParseBool(config.CustomStartScreen);
            LogDownloads = ConfigUtils.ParseBool(config.LogDownloads);
            ChristmasUI = ConfigUtils.ParseBool(config.ChristmasUI);
        }
                
    }
}