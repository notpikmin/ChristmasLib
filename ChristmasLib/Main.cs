using MelonLoader;



[assembly: MelonInfo(typeof(ChristmasLib.Main), "ChristmasLib", "1.0.1", "Pikmin", "http://www.goorlandostore.com")]
[assembly: MelonGame("VRChat", "VRChat")]

namespace ChristmasLib
{
    public class Main : MelonPlugin
    {

       
        public override void OnApplicationEarlyStart()
        {
            
            // Utils.ConsoleUtils.Write("OnApplicationEarlyStart");

            //incomplete melonloader loading image changer
            /// StartMenu.PatchLoad.Start();
            UI.ChristmasUI.InitUI();

            
        }

        public override void OnApplicationStart()
        {

        }

        public override void OnPreInitialization()
        {

            //   Utils.ConsoleUtils.Write("OnPreInitialization");

        }

        public override void OnGUI()
        {

        }


    }
}
