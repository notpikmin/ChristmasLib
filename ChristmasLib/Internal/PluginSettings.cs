using ChristmasLib.Config;

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
        private static readonly string ConfigName = "ChristmasLibConfig.json";

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
            PluginCfg = cfg.Load(PluginCfg);
            ConfigUtils.FileSystemWatcher();            
        }
                
    }
}