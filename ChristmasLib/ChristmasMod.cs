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

        public virtual void OnApplicationStart() 
        {

        }

    }
}
