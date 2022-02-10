using UnityEngine;

namespace ChristmasLib.Utils
{
    public static class ComponentUtils
    {
        public static void DisableAllOf(Il2CppSystem.Type type)
        {
           var comps = UnityEngine.Object.FindObjectsOfType(type);
            foreach(MonoBehaviour m in comps)
            {
                m.enabled = false;
            }
        }

    }
}
