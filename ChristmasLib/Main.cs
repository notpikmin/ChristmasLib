using ChristmasLib.Internal;
using ChristmasLib.UI;
using MelonLoader;

[assembly: MelonInfo(typeof(ChristmasLib.Main), "ChristmasLib", MelonBuildInfo.Version, MelonBuildInfo.Author, "https://www.Christmas.com")]
[assembly: MelonGame("VRChat", "VRChat")]
    
public static class MelonBuildInfo
{
    public const string Version = "1.1.1";
    public const string Author = "Christmas Gang";
    public const string ReleaseVersion = "Public";

}


namespace ChristmasLib  
{
    public class Main : MelonPlugin
    {
        
        public override void OnApplicationEarlyStart()
        {
            PluginSettings.InitSettings();

            if (PluginSettings.PluginCfg.CustomStartScreen)
            {
                StartMenu.StartScreen.Start();
            }

        }

        public override void OnApplicationStart()
        {
            //UI.ChristmasUI.InitUI();

        }   

        public override void OnApplicationLateStart()
        { 
            PatchManager.InitPatches();
            if (PluginSettings.PluginCfg.ChristmasUI)
            {
                MelonCoroutines.Start(ChristmasUI.UICheck());
            }
        }
        
        
        public override void OnPreInitialization()
        {

            //   Utils.ConsoleUtils.Write("OnPreInitialization");

        }

        public override void OnGUI()
        {

        }


        public override void OnUpdate()
        {
            
        }
        
    }
}
