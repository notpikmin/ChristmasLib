using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChristmasLib.Modules
{
    public static class ModuleHandler
    {
        public static List<Module> EnabledMods = new List<Module>();

        public static bool addMod(Module mod)
        {
            if (checkIfMod(mod))
            {
                EnabledMods.Add(mod);
                mod.OnEnable();
                return true;
            }
            return false;
        }

        public static bool removeMod(Module mod)
        {
            if (checkIfMod(mod))
            {
                mod.OnDisable();
                EnabledMods.Remove(mod);
                return true;
            }
            return false;
        }

        public static bool checkIfMod(Module mod)
        {
           return EnabledMods.Contains(mod);
           
        }

        public static void clearMods()
        {
            EnabledMods.Clear();
        }

        public static List<string> getEnabledNames()
        {
            List<string> names = new List<string>();
            foreach (Module m in EnabledMods)
            {
                names.Add(m.GetName());
            }
            return names;
        }

        


    }
}
