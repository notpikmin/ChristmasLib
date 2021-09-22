using System;
using System.Collections.Generic;
using System.Collections;
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

        public static List<string> GetGlobalEvents(UdonBehaviour ub)
        {
            List<string> events = new List<string>();

            foreach (Il2CppSystem.Collections.Generic.KeyValuePair<string, Il2CppSystem.Collections.Generic.List<uint>> e in ub._eventTable)
            {
                if (e.key.StartsWith("_"))
                {
                    events.Add(e.key);
                }
            }

            return events;
        }

    //should work
        public static IEnumerator TriggerAll(Dictionary<UdonBehaviour, List<string>> Udons, float delay = 0.1f)
        {
            foreach(UdonBehaviour u in Udons.Keys)
            {

                List<string> et = new List<string>();
                Udons.TryGetValue(u,out et);

                foreach (string e in et) 
                {
                    yield return null;

                    u.SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, e);
                }
                yield return new WaitForSeconds(delay);

            }

                yield return null;
        }

        //fill an Dictionary with every udon GameObject with its events should be called on scene load so we can have a Dictionary of every Udon GameObject and its events
        public static Dictionary<UdonBehaviour, List<string>> FillDict(bool GlobalTriggerOnly = false)
        {

            UdonBehaviour[] UdonBehavs = GetUdonBehaviours();
            Dictionary<UdonBehaviour, List<string>> EventGameObjects = new Dictionary<UdonBehaviour, List<string>>();
            foreach(UdonBehaviour u in UdonBehavs)
            {
                List<string> events;
                if (GlobalTriggerOnly)
                {
                    events = GetGlobalEvents(u);

                }
                else
                {
                    events = GetEventNames(u);

                }
                EventGameObjects.Add(u, events);

            }

            return EventGameObjects;
        }

        


    }
}
