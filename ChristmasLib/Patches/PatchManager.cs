using ChristmasLib.UI;
using VRC.UI.Elements;

namespace ChristmasLib.Patches
{
    public static class PatchManager
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