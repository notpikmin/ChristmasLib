using ExitGames.Client.Photon;
using Photon.Pun;
using Photon.Realtime;
using System.Linq;
using System.Reflection;
using VRCSDK2;
using VRCSDK2.Validation.Performance;

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

        public static MethodInfo EmojiEvent = typeof(VRC_EventDispatcherRFC).GetMethod("Method_Public_Void_Player_VrcEvent_VrcBroadcastType_Int32_Single_0");

        public static MethodInfo Emoji = typeof(VRCPlayer).GetMethod("SpawnEmojiRPC");

        //from Chromatic api 
        //JoinAndLeave[0] = join
        //JoinAndLeave[1] = leave
        public static MethodInfo[] JoinAndLeave = typeof(NetworkManager).GetMethods().Where(m =>
         m.Name.Contains("Method_Public_Void_Player_") &&
         !m.Name.Contains("PDM")
        ).ToArray();

        //May break in future
        public static MethodInfo[] CalculatePerformance = typeof(AvatarPerformance).GetMethods().Where(m =>
        m.Name.Contains("_AvatarPerformanceStats_") &&
        m.Name.StartsWith("Method")
       ).ToArray();


        //believe is outdated
        public static MethodInfo SwitchAvatarMethod
        {
            get
            {
                if (Switchavamethod == null)
                {
                    MethodInfo[] methods = typeof(VRCPlayer).GetMethods(BindingFlags.Instance | BindingFlags.Public);
                    foreach (MethodInfo methodInfo in methods)
                    {
                        if (methodInfo.Name.Contains("Private") && methodInfo.ReturnType == typeof(void) && methodInfo.GetParameters().Length == 1 && methodInfo.GetParameters()[0].ParameterType == typeof(bool) && methodInfo.GetParameters()[0].HasDefaultValue)
                        {
                            Switchavamethod = methodInfo;
                            return Switchavamethod;
                        }
                    }
                }
                return Switchavamethod;
            }
        }

        internal static MethodInfo Switchavamethod;
    }
}
