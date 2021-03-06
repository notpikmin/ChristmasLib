using System.Collections.Generic;
using System.Collections;
using VRC.Udon;
using UnityEngine;
namespace ChristmasLib.Utils
{
    public static class UdonUtils
    {

        #region Getting
        public static UdonBehaviour[] GetUdonBehaviours()
        {
            return Resources.FindObjectsOfTypeAll<UdonBehaviour>();
        }

        
        public static List<string> GetEventNames(UdonBehaviour ub)
        {
            List<string> events = new List<string>();

            foreach (var e in ub._eventTable)
            {
                events.Add(e.key);
            }

            return events;
        }

        public static List<string> GetGlobalEvents(UdonBehaviour ub)
        {
            var events = new List<string>();

            foreach (var e in ub._eventTable)
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

            UdonBehaviour[] udonBehaviours = GetUdonBehaviours();
            var eventGameObjects = new Dictionary<UdonBehaviour, List<string>>();
            foreach(var u in udonBehaviours)
            {
                
                var events = globalTriggerOnly ? GetGlobalEvents(u) : GetEventNames(u);

                //dont add the behaviour if it contains no events
                
                if (events.Count > 0)
                {
                    eventGameObjects.Add(u, events);
                }

            }

            return eventGameObjects;
        }
        
        

        #endregion
        
        #region Trigger
        public static IEnumerator TriggerAll(Dictionary<UdonBehaviour, List<string>> udons, float delay = 0.05f)
        {
            
            foreach (var u in udons.Keys)
            {
                List<string> et;
                udons.TryGetValue(u, out et);
                if (et == null) { continue; }

                foreach (var e in et)
                {
                    yield return null;
                    u.SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, e);
                }

                yield return new WaitForSeconds(delay);

            }
            

            yield return null;
        }

      #endregion

    }
}
