using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using ChristmasLib.Patches;
using HarmonyLib;
using UnityEngine;

namespace ChristmasLib.StartMenu
{
    static internal class PatchLoad
    {
        //incomplete melonloader loading image changer
        public static void Start()
        {
            /*
            List<Assembly> Assms = AccessTools.AllAssemblies().ToList<Assembly>();
            foreach(Assembly a in Assms)
            {
                Console.WriteLine(a.FullName);
            }
            //Patches.Patch loadPatch = new Patches.Patch("RenderPatch", load,PatchUtils.getMethod(typeof(PatchLoad), "RenderPrefix"),null);
            */
        }

        private static bool RenderPrefix(string __0, FilterMode __1)
        {
            Console.WriteLine("FART");
            return false;
        }


    }
}
