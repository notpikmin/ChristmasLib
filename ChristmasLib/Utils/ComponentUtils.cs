using UnityEngine;

namespace ChristmasLib.Utils
{
    public static class ComponentUtils
    {
        public static void DisableAllOf(Il2CppSystem.Type type)
        {
           var comps = Object.FindObjectsOfType(type);
            foreach(var o in comps)
            {
                var m = (MonoBehaviour) o;
                m.enabled = false;
            }
        }

    }
}
