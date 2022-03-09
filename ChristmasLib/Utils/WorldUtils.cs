using System.Collections.Generic;
using VRC.SDKBase;

namespace ChristmasLib.Utils
{
    public static class WorldUtils
    {
        
        #region WorldType
        public enum WorldType
        {
            Udon,
            SDK2,
            None
        }

        //believe this is faster then below
        public static WorldType GetWorldType()
        {
            VRC_SceneDescriptor sceneDescriptor = GetSceneDescriptor();

            if (sceneDescriptor.gameObject.GetComponent<VRC.SDK3.Components.VRCSceneDescriptor>() != null)
            {
                return WorldType.Udon;
            }
            return sceneDescriptor.gameObject.GetComponent<VRCSDK2.VRC_SceneDescriptor>() != null ? WorldType.SDK2 : WorldType.None;

        }
        
        /*
        public static WorldType GetWorldType()
        {
            if (UnityEngine.Object.FindObjectOfType<VRC.SDK3.Components.VRCSceneDescriptor>() != null)
            {
                return WorldType.Udon;
            }
            return UnityEngine.Object.FindObjectOfType<VRCSDK2.VRC_SceneDescriptor>() != null ? WorldType.SDK2 : WorldType.None;
        }
        */
        
        //^ this could probably use this
        public static VRC_SceneDescriptor GetSceneDescriptor()
        {
            return VRC_SceneDescriptor.Instance;
        }

        #endregion
        
        #region Instantiator

        //instantiate stuff might move somewhere else
        public static ObjectInstantiator GetObjectInstantiator()
        {
            return UnityEngine.Object.FindObjectOfType<ObjectInstantiator>();
        }

        public static List<string> GetInstantiableObjects()
        {
            ObjectInstantiator objI = GetObjectInstantiator();
            List<string> objs = new List<string>();
            foreach(string s in objI.field_Private_Dictionary_2_String_PrefabInfo_0.keys)
            {
                objs.Add(s);
            }
            return objs;
        }

        #endregion
        
    }
}
