using System.Collections.Generic;
using UnityEngine;
using VRC.SDKBase;

namespace ChristmasLib.Utils
{
    public static class EventUtils
    {
        private static VRC_EventHandler EventHandler = null;

        public static VRC_EventHandler GetEventHandler()
        {
          
                EventHandler = UnityEngine.Object.FindObjectOfType<VRC_EventHandler>();
                return EventHandler;
                
        }

        //param aids
        public static VRC_EventHandler.VrcEvent MakeEvent(string ParamString, GameObject ParamObject, Il2CppSystem.Object[] Array, VRC_EventHandler.VrcEventType ParamEventType = VRC_EventHandler.VrcEventType.SendRPC ,string ParamName = "",float ParamFloat = 0f, int ParamInt = 0, bool TakeOwnershipOfTarget = false, bool ParamBool=false, VRC_EventHandler.VrcBooleanOp ParamBoolOp = VRC_EventHandler.VrcBooleanOp.Unused)
        {

            VRC_EventHandler.VrcEvent vrcEvent = new VRC_EventHandler.VrcEvent
            {
                EventType = ParamEventType,
                Name = ParamName,
                ParameterString = ParamString,
                ParameterBytes = Networking.EncodeParameters(Array
                                ),
                ParameterFloat = ParamFloat,
                ParameterInt = ParamInt,
                ParameterBool = ParamBool,
                ParameterBoolOp = ParamBoolOp,
                TakeOwnershipOfTarget = TakeOwnershipOfTarget,
                ParameterObject = ParamObject,
                ParameterObjects = null
            };
            return vrcEvent;
        }
        //Simplified Method
        public static VRC_EventHandler.VrcEvent MakeEvent(string ParamString, GameObject ParamObject, Il2CppSystem.Object[] Array)
        {

            VRC_EventHandler.VrcEvent vrcEvent = new VRC_EventHandler.VrcEvent
            {
                EventType = VRC_EventHandler.VrcEventType.SendRPC,
                Name = "",
                ParameterString = ParamString,
                ParameterBytes = Networking.EncodeParameters(Array
                                ),
                ParameterFloat = 0,
                ParameterInt = 0,
                ParameterBool = false,
                ParameterBoolOp = VRC_EventHandler.VrcBooleanOp.Unused,
                TakeOwnershipOfTarget = false,
                ParameterObject = ParamObject,
                ParameterObjects = null
            };
            return vrcEvent;
        }


        public static void TriggerEvent(VRC_EventHandler.VrcEvent Event,VRC_EventHandler.VrcBroadcastType BroadcastType = VRC_EventHandler.VrcBroadcastType.Always)
        {
            if (EventHandler == null)
            {
                EventHandler = GetEventHandler();
            }
            EventHandler.TriggerEvent(Event, BroadcastType);
            
        }



        public static Il2CppSystem.Object[] StringListToObject(List<string> str)
        {
            
            Il2CppSystem.Object[] array = new Il2CppSystem.Object[str.Count];
            int c = 0;
            foreach(string s in str)
            {
                //I dont know if this is needed but I've seen it done in most places.
                Il2CppSystem.String il2S = default(Il2CppSystem.String);
                il2S = s;
                //array[c] = s; maybe
                array[c] = il2S;
                //seems retarded    
                c++;
            }
            return array;
        }
        
        
        //no position overload
        public static GameObject Instantiate(string obj)
        {
            return Instantiate(obj, new Vector3(0,0,0));
        }

        public static GameObject Instantiate(string obj, Vector3 pos)
        {
            return Networking.Instantiate(VRC_EventHandler.VrcBroadcastType.Always, "Portals/PortalInternalDynamic", pos, Quaternion.identity);

        }
        //rotate :D
        public static GameObject Instantiate(string obj,Vector3 pos,Quaternion rot)
        {
            return Networking.Instantiate(VRC_EventHandler.VrcBroadcastType.Always, "Portals/PortalInternalDynamic", pos,rot);

        }

        public static void SendRPC(GameObject gameObject, string methodName, Il2CppSystem.Object[] array, RPC.Destination target = RPC.Destination.All)
        {
            Networking.RPC(target, gameObject, methodName, array);
        }
    }
}

