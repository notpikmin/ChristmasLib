using System.Collections.Generic;
using System.Collections;
using VRC.Udon;
using UnityEngine;
namespace ChristmasLib.Utils.Udon
{
    public static class UdonUtils
    {

        #region Getting
        public static UdonBehaviour[] GetUdonBehaviours()
        {
            return Object.FindObjectsOfType<UdonBehaviour>();
            
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
                if (!e.key.StartsWith("_"))
                {
                    events.Add(e.key);
                }
            }

            return events;
        }
        
        //fill an Dictionary with every udon GameObject with its events should be called on scene load so we can have a Dictionary of every Udon GameObject and its events
        public static Dictionary<UdonBehaviour, List<string>> FillDict(bool globalTriggerOnly = false)
        {

            UdonBehaviour[] udonBehavs = GetUdonBehaviours();
            Dictionary<UdonBehaviour, List<string>> eventGameObjects = new Dictionary<UdonBehaviour, List<string>>();
            foreach(UdonBehaviour u in udonBehavs)
            {
                List<string> events;
                if (globalTriggerOnly)
                {
                    events = GetGlobalEvents(u);

                }
                else
                {
                    events = GetEventNames(u);

                }
                eventGameObjects.Add(u, events);

            }

            return eventGameObjects;
        }

        #endregion
        
        #region Trigger
        //should work
        public static IEnumerator TriggerAll(Dictionary<UdonBehaviour, List<string>> udons, float delay = 0.1f)
        {
            foreach (UdonBehaviour u in udons.Keys)
            {

                List<string> et;
                udons.TryGetValue(u, out et);

                if (et != null)
                {
                    foreach (string e in et)
                    {
                        yield return null;

                        u.SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, e);
                    }

                    yield return new WaitForSeconds(delay);

                }
            }

            yield return null;
        }

      #endregion

    }
}
