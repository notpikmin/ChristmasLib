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

        public static HarmonyMethod getMethod(Type classType, string method, BindingFlags bfStatic = BindingFlags.Static, BindingFlags bfPublic = BindingFlags.NonPublic)
        {
            return new HarmonyMethod(classType.GetMethod(method, bfStatic | bfPublic));
        }

    }
}
