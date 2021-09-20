using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VRC.Udon;
using UnityEngine;
namespace ChristmasLib.Utils
{
    public static class UdonUtils
    {

        public static UdonBehaviour[] GetUdonBehaviours()
        {
            return UnityEngine.Object.FindObjectsOfType<UdonBehaviour>();
        }


        public static List<string> GetEventNames(UdonBehaviour ub)
        {
            List<string> events = new List<string>();

            foreach (Il2CppSystem.Collections.Generic.KeyValuePair<string, Il2CppSystem.Collections.Generic.List<uint>> e in ub._eventTable)
            {
                events.Add(e.key);
            }

            return events;
        }

        //fills the static UdonDict should be called on scene load so we can have a Dictionary of every Udon GameObject and its events
        public static void FillDict()
        {
            //Don't believe this is needed
            if (UdonDict != null)
            {
                UdonDict.Clear();
            }
            UdonBehaviour[] UdonBehavs = GetUdonBehaviours();
            Dictionary<GameObject,List<string>> EventGameObjects = new Dictionary<GameObject,List<string>>();
            foreach(UdonBehaviour u in UdonBehavs)
            {
                List<string> events = GetEventNames(u);
                EventGameObjects.Add(u.gameObject, events);
            }

            UdonDict = EventGameObjects;
        }

        public static Dictionary<GameObject,List<string>> UdonDict;
        


    }
}
