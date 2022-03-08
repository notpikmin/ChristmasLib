using ChristmasLib.Internal;
using ChristmasLib.UI;
using MelonLoader;

[assembly: MelonInfo(typeof(ChristmasLib.Main), "ChristmasLib", "1.0.3", "pikk and toboyo not tope though", "https://www.goorlandostore.com")]
[assembly: MelonGame("VRChat", "VRChat")]

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
