using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChristmasLib.Modules
{
    public static class ModuleHandler
    {
        public static List<ChristmasMod> EnabledMods = new List<ChristmasMod>();

        public static bool addMod(ChristmasMod mod)
        {
            if (checkIfMod(mod))
            {
                EnabledMods.Add(mod);
                mod.OnEnable();
                return true;
            }
            return false;
        }

        public static bool removeMod(ChristmasMod mod)
        {
            if (checkIfMod(mod))
            {
                mod.OnDisable();
                EnabledMods.Remove(mod);
                return true;
            }
            return false;
        }

        public static bool checkIfMod(ChristmasMod mod)
        {
           return EnabledMods.Contains(mod);
           
        }

        public static void clearMods()
        {
            foreach(ChristmasMod m in EnabledMods)
            {
                m.OnDisable();
            }
            EnabledMods.Clear();
        }

        public static void updateAll()
        {
            foreach(ChristmasMod m in EnabledMods)
            {
                m.Update();
            }
        }



        public static List<string> getEnabledNames()
        {
            List<string> names = new List<string>();
            foreach (ChristmasMod m in EnabledMods)
            {
                names.Add(m.GetName());
            }
            return names;
        }

        


    }
}
