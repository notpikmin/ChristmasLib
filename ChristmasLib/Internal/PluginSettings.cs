using ChristmasLib.Config;
// ReSharper disable ConvertToConstant.Global
// ReSharper disable FieldCanBeMadeReadOnly.Global

namespace ChristmasLib.Internal
{
    
    public class PluginConfig
    {
        public bool Debug = false;
        public bool CustomStartScreen = true;
        public bool LogDownloads = true;
        public bool ChristmasUI = true;
    }
    
    public static class PluginSettings
    {
        private const string ConfigName = "ChristmasLibConfig.json";

        public static PluginConfig PluginCfg;
        //public static bool Debug,CustomStartScreen,LogDownloads,ChristmasUI;
        public static void InitSettings(){
        
            PluginCfg = new PluginConfig();
            //ugly needs rewrite
            ChristmasConfig cfg = new ChristmasConfig(ConfigName,
                () =>
                {
                    PluginCfg = ChristmasConfig.Load(PluginCfg, ConfigName);
                    
                });
            PluginCfg = ChristmasConfig.Load(PluginCfg, ConfigName,true);
            ConfigUtils.FileSystemWatcher();            
        }
                
    }
}