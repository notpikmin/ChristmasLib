using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using VRC.Udon;

namespace ChristmasLib.Utils
{
    public static class ComponentUtils
    {

        

        public static void DisableAllOf(Il2CppSystem.Type type)
        {
           var comps =   UnityEngine.Object.FindObjectsOfType(type);
            foreach(MonoBehaviour m in comps)
            {
                m.enabled = false;
            }
        }

    }
}
