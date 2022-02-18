using HarmonyLib;
using System;
using System.Reflection;

namespace ChristmasLib.Patches
{
    public static class PatchUtils
    {


        public static Patch DoPatch(string id, MethodInfo target, HarmonyMethod prefix = null, HarmonyMethod postfix = null)
        {
            Patch p = new Patch(id, target, prefix, postfix);
            return p;
        }

        public static HarmonyMethod GetMethod(Type classType, string method, BindingFlags bfStatic = BindingFlags.Static, BindingFlags bfPublic = BindingFlags.NonPublic)
        {
            return new HarmonyMethod(classType.GetMethod(method, bfStatic | bfPublic));
        }

    }
}
