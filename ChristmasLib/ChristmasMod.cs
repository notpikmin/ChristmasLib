using MelonLoader;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace ChristmasLib
{
    public abstract class ChristmasMod :MelonMod
    {
        public virtual void OnSceneWasLoaded(int buildIndex, string sceneName) { }

        public virtual void OnSceneWasInitialized(int buildIndex, string sceneName) { }

        public virtual void OnSceneWasUnloaded(int buildIndex,string sceneName) { }

        public virtual void OnFixedUpdate() { }

        public virtual void OnUIInit() { }
        public virtual void OnStart() { }

      


        private IEnumerator CheckForUi()
        {
            while (VRCUiManager.prop_VRCUiManager_0 == null)
            {
                yield return null;

            }
            while (QuickMenu.prop_QuickMenu_0 == null)
            {
                yield return null;
            }
            yield return null;
            OnUIInit();
        }
        public override void OnApplicationStart() 
        {
            OnStart();
            MelonCoroutines.Start(CheckForUi());

        }

    }
}
