using ChristmasLib.Patches;
using ChristmasLib.UI;
using UnityEngine;

namespace ChristmasLib.Internal
{
    internal static class PatchManager
    {
        public static void InitPatches()
        {
            PatchUtils.DoPatch("MenuPatch", PatchDefine.MenuOpen, null, PatchUtils.GetMethod(typeof(PatchManager), "OnMenu"));

        }

        // ReSharper disable once InconsistentNaming stupid harmony 
        private static void OnMenu(Object __instance)
        {
            if (__instance.name.Contains("Canvas"))
            {
                ChristmasUI.UpdateStatus();
            }
        }
        
    
    }
}