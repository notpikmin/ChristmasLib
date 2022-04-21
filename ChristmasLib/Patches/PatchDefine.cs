using ExitGames.Client.Photon;
using Photon.Pun;
using Photon.Realtime;
using System.Linq;
using System.Reflection;
using VRC.SDKBase.Validation.Performance;
using VRC.UI.Elements;
using VRCSDK2;

namespace ChristmasLib.Patches
{
  
    public static class PatchDefine
    {

        #region Photon
        
        public static MethodInfo LoadBalanceRaiseEvent = typeof(LoadBalancingClient).GetMethod("Method_Public_Virtual_New_Boolean_Byte_Object_RaiseEventOptions_SendOptions_0");
        public static MethodInfo LoadBalanceEvent = typeof(LoadBalancingClient).GetMethod("OnEvent");

        public static MethodInfo PhotonRaiseEvent = typeof(PhotonNetwork).GetMethod("Method_Public_Static_Boolean_Byte_Object_RaiseEventOptions_SendOptions_0");
        public static MethodInfo PhotonEvent = typeof(PhotonNetwork).GetMethod("Method_Private_Static_Void_EventData_PDM_0");

        public static MethodInfo EnetEnqueue = typeof(EnetPeer).GetMethod("EnqueueOperation");

        #endregion
        
        #region Event
        public static MethodInfo InternalTrigger = typeof(VRC_EventHandler).GetMethod(nameof(VRC_EventHandler.InternalTriggerEvent));


        public static MethodInfo EmojiEvent = typeof(VRC_EventDispatcherRFC).GetMethod("Method_Public_Void_Player_VrcEvent_VrcBroadcastType_Int32_Single_0");

        public static MethodInfo Emoji = typeof(VRCPlayer).GetMethod(nameof(VRCPlayer.SpawnEmojiRPC));

        #endregion

        #region JoinAndLeave
        
        public static MethodInfo LocalLeave = typeof(NetworkManager).GetMethod(nameof(NetworkManager.OnJoinedRoom));
        public static MethodInfo LocalJoin = typeof(NetworkManager).GetMethod(nameof(NetworkManager.OnJoinedRoom));

        
        //from Chromatic api 
        //JoinAndLeave[1] = join
        //JoinAndLeave[0] = leave
        //changes often :/
        public static MethodInfo[] JoinAndLeave = typeof(NetworkManager).GetMethods().Where(m =>
         m.Name.Contains("Method_Public_Void_Player_") &&
         !m.Name.Contains("PDM")
        ).ToArray();
        #endregion
        
        #region Avatar
        
        //May break in future
        public static MethodInfo[] CalculatePerformance = typeof(AvatarPerformance).GetMethods().Where(m =>
        m.Name.Contains("_AvatarPerformanceStats_") &&
        m.Name.StartsWith("Method") && 
        m.Name.Contains("String")
       ).ToArray();


        //believe is outdated
        public static MethodInfo SwitchAvatarMethod
        {
            get
            {
                if (Switchavamethod != null) return Switchavamethod;
                MethodInfo[] methods = typeof(VRCPlayer).GetMethods(BindingFlags.Instance | BindingFlags.Public);
                foreach (MethodInfo methodInfo in methods)
                {
                    //only continue if the method is private, returns void, the parameter length is 1 and its bool with a default value
                    if (!methodInfo.Name.Contains("Private") || methodInfo.ReturnType != typeof(void) || methodInfo.GetParameters().Length != 1 ||
                        methodInfo.GetParameters()[0].ParameterType != typeof(bool) || !methodInfo.GetParameters()[0].HasDefaultValue) continue;
                    Switchavamethod = methodInfo;
                    return Switchavamethod;
                }
                return Switchavamethod;
            }
        }

        public static MethodInfo Switchavamethod;
        
        #endregion

        #region Menu

        public static MethodInfo MenuOpen = typeof(MenuStateController).GetMethod("Method_Private_Void_0");
        
        #endregion
    }
}
