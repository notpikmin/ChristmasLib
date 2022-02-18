using HarmonyLib;
using System.Collections.Generic;
using System.Reflection;


namespace ChristmasLib.Patches
{
    public class Patch
    {

        public string ID { get; set; }


        public MethodBase TargetMethod { get; set; }


        public HarmonyMethod Prefix { get; set; }

        public HarmonyMethod Postfix { get; set; }


        public Patch(string identifier, MethodBase target, HarmonyMethod before, HarmonyMethod after)
        {
            ID = identifier;
            TargetMethod = target;
            Prefix = before;
            Postfix = after;
            if (!PatchIDs.ContainsKey(ID))
            {
                HarmonyLib.Harmony instance = new HarmonyLib.Harmony(ID);
                PatchIDs.Add(ID, instance);
            }
            PatchIDs[ID].Patch(TargetMethod, Prefix, Postfix);
        }

        public static Dictionary<string, HarmonyLib.Harmony> PatchIDs = new Dictionary<string, HarmonyLib.Harmony>();
    }


}
