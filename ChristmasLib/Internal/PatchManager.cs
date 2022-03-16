using ChristmasLib.Patches;
using ChristmasLib.UI;
using VRC.UI.Elements;

namespace ChristmasLib.Internal
{
    internal static class PatchManager
    {
        public static void InitPatches()
        {
            PatchUtils.DoPatch("MenuPatch", PatchDefine.MenuOpen, null, PatchUtils.GetMethod(typeof(PatchManager), "OnMenu"));

        }

        private static void OnMenu(MenuStateController __instance)
        {
            if (__instance.name.Contains("Canvas"))
            {
                ChristmasUI.UpdateStatus();
            }
        }
        
    
    }
}