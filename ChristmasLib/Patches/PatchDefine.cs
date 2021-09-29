using ExitGames.Client.Photon;
using HarmonyLib;
using Photon.Pun;
using Photon.Realtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using VRCSDK2;

namespace ChristmasLib.Patches
{
    public static class PatchDefine
    {

        public static MethodInfo LoadBalanceRaiseEvent = typeof(LoadBalancingClient).GetMethod("Method_Public_Virtual_New_Boolean_Byte_Object_RaiseEventOptions_SendOptions_0");
        public static MethodInfo LoadBalanceEvent = typeof(LoadBalancingClient).GetMethod("OnEvent");

        public static MethodInfo PhotonRaiseEvent = typeof(PhotonNetwork).GetMethod("Method_Public_Static_Boolean_Byte_Object_RaiseEventOptions_SendOptions_0");
        public static MethodInfo PhotonEvent = typeof(PhotonNetwork).GetMethod("Method_Private_Static_Void_EventData_PDM_0");

        public static MethodInfo InternalTrigger = typeof(VRC_EventHandler).GetMethod("InternalTriggerEvent");

        public static MethodInfo EnetEnqueue = typeof(EnetPeer).GetMethod("EnqueueOperation");




        public static MethodInfo SwitchAvatarMethod
        {
            get
            {
                if (switchavamethod == null)
                {
                    MethodInfo[] methods = typeof(VRCPlayer).GetMethods(BindingFlags.Instance | BindingFlags.Public);
                    foreach (MethodInfo methodInfo in methods)
                    {
                        if (methodInfo.Name.Contains("Private") && methodInfo.ReturnType == typeof(void) && methodInfo.GetParameters().Length == 1 && methodInfo.GetParameters()[0].ParameterType == typeof(bool) && methodInfo.GetParameters()[0].HasDefaultValue)
                        {
                            switchavamethod = methodInfo;
                            return switchavamethod;
                        }
                    }
                }
                return switchavamethod;
            }
        }

        internal static MethodInfo switchavamethod;
    }
}
