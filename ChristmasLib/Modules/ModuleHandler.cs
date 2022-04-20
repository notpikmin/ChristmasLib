using System.Collections.Generic;
using System.Linq;

namespace ChristmasLib.Modules
{
    public class ModuleHandler
    {
        public List<ChristmasModule> EnabledMods = new List<ChristmasModule>();

        public void AddMod(ChristmasModule mod)
        {
            if (CheckIfMod(mod)) return;
            EnabledMods.Add(mod);
            mod.OnEnable();
        }

        public void RemoveMod(ChristmasModule mod)
        {
            if (!CheckIfMod(mod)) return;
            mod.OnDisable();
            EnabledMods.Remove(mod);
        }

        public bool CheckIfMod(ChristmasModule mod)
        {
            return GetEnabledNames().Contains(mod.ModuleName);
        }

        public void ClearMods()
        {
            foreach (ChristmasModule m in EnabledMods)
            {
                m.OnDisable();
            }

            EnabledMods.Clear();
        }


        public void UpdateAll()
        {
            foreach (ChristmasModule m in EnabledMods)
            {
                m.Update();
            }
        }

        public void CallOnGUI()
        {
            foreach (ChristmasModule m in EnabledMods)
            {
                m.OnGUI();
            }
        }

        public void LoadAllSettings()
        {
            foreach (ChristmasModule m in EnabledMods)
            {
                m.OnSettingsLoad();
            }
        }

        public void CallOnLeave()
        {
            foreach (ChristmasModule m in EnabledMods)
            {
                m.OnLeaveWorld();
            }
        }

        public void CallOnJoin()
        {
            foreach (ChristmasModule m in EnabledMods)
            {
                m.OnJoinWorld();
            }
        }

        public List<string> GetEnabledNames()
        {
            //put every modules name to a list
            return EnabledMods.Select(m => m.ModuleName).ToList();
        }
    }
}