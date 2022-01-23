using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ChristmasLib.Patches
{
    public class Patch
    {

        public string ID { get; set; }


        public MethodBase TargetMethod { get; set; }


        public HarmonyMethod Prefix { get; set; }

        public HarmonyMethod Postfix { get; set; }


        public Patch(string Identifier, MethodBase Target, HarmonyMethod Before, HarmonyMethod After)
        {
            this.ID = Identifier;
            this.TargetMethod = Target;
            this.Prefix = Before;
            this.Postfix = After;
            if (!Patch.PatchIDs.ContainsKey(this.ID))
            {
                HarmonyLib.Harmony instance = new HarmonyLib.Harmony(this.ID);
                Patch.PatchIDs.Add(this.ID, instance);
            }
            Patch.PatchIDs[this.ID].Patch(this.TargetMethod, this.Prefix, this.Postfix, null);
        }

        public static Dictionary<string, HarmonyLib.Harmony> PatchIDs = new Dictionary<string, HarmonyLib.Harmony>();
    }


}
