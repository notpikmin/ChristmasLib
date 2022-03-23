using System.Collections.Generic;

namespace ChristmasLib.Modules
{
    public class ModuleHandler
    {
        
        //TODO Convert to Dictionary<string,ChristmasModule> will break old modules unless make an overload method for adding mods
        public List<ChristmasModule> EnabledMods = new List<ChristmasModule>();

        //TODO Fix CheckIfMod always returning true
        public void AddMod(ChristmasModule mod)
        {
            
            //if (CheckIfMod(mod))
            //{
                EnabledMods.Add(mod);
                mod.OnEnable();
           // }
        }

        public void RemoveMod(ChristmasModule mod)
        {
            //if (CheckIfMod(mod))
            //{
                mod.OnDisable();
                EnabledMods.Remove(mod);
            //}
        }

        public bool CheckIfMod(ChristmasModule mod)
        {
           return EnabledMods.Contains(mod);
           
        }

        public void ClearMods()
        {
            foreach(ChristmasModule m in EnabledMods)
            {
                m.OnDisable();
            }
            EnabledMods.Clear();
        }
        
        

        public void UpdateAll()
        {
            foreach(ChristmasModule m in EnabledMods)
            {
                m.Update();
            }
        }
        
        
        public void LoadAllSettings()
        {
            foreach(ChristmasModule m in EnabledMods)
            {
                m.OnSettingsLoad();
            }
        }
        
        public void CallOnLeave()
        {
            foreach(ChristmasModule m in EnabledMods)
            {
                m.OnLeaveWorld();
            }
        }

        public void CallOnJoin()
        {
            foreach(ChristmasModule m in EnabledMods)
            {
                m.OnJoinWorld();
            }
        }

        public List<string> GetEnabledNames()
        {
            List<string> names = new List<string>();
            foreach (ChristmasModule m in EnabledMods)
            {
                names.Add(m.GetName());
            }
            return names;
        }

        


    }
}
