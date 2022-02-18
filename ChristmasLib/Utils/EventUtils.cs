using System.Collections.Generic;
using UnityEngine;
using VRC.SDKBase;

namespace ChristmasLib.Utils
{
    public static class EventUtils
    {
        private static VRC_EventHandler _eventHandler;

        public static VRC_EventHandler GetEventHandler()
        {
          
                _eventHandler = Object.FindObjectOfType<VRC_EventHandler>();
                return _eventHandler;
                
        }

        //param aids
        public static VRC_EventHandler.VrcEvent MakeEvent(string paramString, GameObject paramObject, Il2CppSystem.Object[] array, VRC_EventHandler.VrcEventType paramEventType = VRC_EventHandler.VrcEventType.SendRPC ,string paramName = "",float paramFloat = 0f, int paramInt = 0, bool takeOwnershipOfTarget = false, bool paramBool=false, VRC_EventHandler.VrcBooleanOp paramBoolOp = VRC_EventHandler.VrcBooleanOp.Unused)
        {

            VRC_EventHandler.VrcEvent vrcEvent = new VRC_EventHandler.VrcEvent
            {
                EventType = paramEventType,
                Name = paramName,
                ParameterString = paramString,
                ParameterBytes = Networking.EncodeParameters(array
                                ),
                ParameterFloat = paramFloat,
                ParameterInt = paramInt,
                ParameterBool = paramBool,
                ParameterBoolOp = paramBoolOp,
                TakeOwnershipOfTarget = takeOwnershipOfTarget,
                ParameterObject = paramObject,
                ParameterObjects = null
            };
            return vrcEvent;
        }
      

        public static void TriggerEvent(VRC_EventHandler.VrcEvent @event,VRC_EventHandler.VrcBroadcastType broadcastType = VRC_EventHandler.VrcBroadcastType.Always)
        {
            if (_eventHandler == null)
            {
                _eventHandler = GetEventHandler();
            }
            _eventHandler.TriggerEvent(@event, broadcastType);
            
        }



        public static Il2CppSystem.Object[] StringListToObject(List<string> str)
        {
            
            Il2CppSystem.Object[] array = new Il2CppSystem.Object[str.Count];
            int c = 0;
            foreach(string s in str)
            {
                //I dont know if this is needed but I've seen it done in most places.
                Il2CppSystem.String il2S;
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
            return Networking.Instantiate(VRC_EventHandler.VrcBroadcastType.Always, obj , pos, Quaternion.identity);

        }
        //rotate :D
        public static GameObject Instantiate(string obj,Vector3 pos,Quaternion rot)
        {
            return Networking.Instantiate(VRC_EventHandler.VrcBroadcastType.Always, obj, pos,rot);

        }

        public static void SendRPC(GameObject gameObject, string methodName, Il2CppSystem.Object[] array, RPC.Destination target = RPC.Destination.All)
        {
            Networking.RPC(target, gameObject, methodName, array);
        }
    }
}

