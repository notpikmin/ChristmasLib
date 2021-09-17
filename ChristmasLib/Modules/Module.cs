using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChristmasLib.Modules
{
   public class Module
    {
        private static string ModuleName = "Base Module";
        public virtual string GetName()
        {
            return ModuleName;
        }

        public virtual void Start()
        {

        }

        public virtual void Update()
        {

        }

        public virtual void UiInit()
        {

        }
        public virtual void OnApplicationQuit()
        {

        }
        public virtual void OnSceneWasInitialized()
        {

        }
        public virtual void OnSceneWasLoaded()
        {

        }
        public virtual void OnLateUpdate()
        {

        }
        public virtual void OnFixedUpdate()
        {

        }

        public virtual void OnGUI()
        {

        }

        public virtual void OnPreferencesLoaded()
        {

        }
        public virtual void OnPreferencesSaved()
        {

        }
    }
}
