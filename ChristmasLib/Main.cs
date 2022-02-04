using MelonLoader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using MelonLoader.MelonStartScreen.UI;
[assembly: MelonInfo(typeof(ChristmasLib.Main), "ChristmasLib", "1.0.1", "Pikmin", "http://www.goorlandostore.com")]
[assembly: MelonGame("VRChat", "VRChat")]

namespace ChristmasLib
{
    public class Main : MelonPlugin
    {

        //UI.ChristmasUI ui = new UI.ChristmasUI();
       
        public override void OnApplicationEarlyStart()
        {
            // ui.Setup();
            // Utils.ConsoleUtils.Write("OnApplicationEarlyStart");

            //incomplete melonloader loading image changer
            /// StartMenu.PatchLoad.Start();
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
