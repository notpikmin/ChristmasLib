using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using VRC.SDKBase;

namespace ChristmasLib.Utils
{
    public static class PhotonUtils
    {
        private static VRC_EventHandler eventHandler = null;
        public static VRC_EventHandler getEventHandler()
        {
            if (eventHandler == null)
            {
                eventHandler = UnityEngine.Object.FindObjectOfType<VRC_EventHandler>();
                return eventHandler;
            }
            else
            {
                return eventHandler;
            }
        }

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
    }
}

