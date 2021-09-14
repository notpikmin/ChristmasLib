using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ChristmasLib.Patches
{
    public static class PatchUtils
    {
        public static void doPatch(string Id, MethodInfo Target, HarmonyMethod prefix = null, HarmonyMethod postfix = null)
        {
            Patch p = new Patch(Id, Target, prefix, postfix);

        }
    }
}
