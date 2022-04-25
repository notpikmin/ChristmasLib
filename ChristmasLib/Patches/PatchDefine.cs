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
        
        /// <summary>
        /// bool LoadBalanceRaiseEvent(byte eventCode, Object data, RaiseEventOptions raiseEventOptions, SendOptions sendOptions)
        /// </summary>
        public static readonly MethodInfo LoadBalanceRaiseEvent = typeof(LoadBalancingClient).GetMethod(
            nameof(LoadBalancingClient.Method_Public_Virtual_New_Boolean_Byte_Object_RaiseEventOptions_SendOptions_0));
       
        /// <summary>
        /// void LoadBalanceEvent(EventData eventData)
        /// </summary>
        public static readonly MethodInfo LoadBalanceEvent = typeof(LoadBalancingClient).GetMethod( nameof(LoadBalancingClient.OnEvent));

        /// <summary>
        /// bool PhotonRaiseEvent(byte eventCode, Object data, RaiseEventOptions raiseEventOptions, SendOptions sendOptions)
        /// </summary>
        public static readonly MethodInfo PhotonRaiseEvent = typeof(PhotonNetwork).GetMethod(
            nameof(PhotonNetwork.Method_Public_Static_Boolean_Byte_Object_RaiseEventOptions_SendOptions_0));
        
        /// <summary>
        /// void PhotonEvent(EventData eventData)
        /// </summary>
        public static readonly MethodInfo PhotonEvent = typeof(PhotonNetwork).GetMethod(
            nameof(PhotonNetwork.Method_Private_Static_Void_EventData_PDM_0));

        //not valid anymore
        //public static MethodInfo EnetEnqueue = typeof(EnetPeer).GetMethod("EnqueueOperation");

        #endregion
        
        #region Event
        
        /// <summary>
        /// void InternalTriggerEvent(VrcEvent e, VrcBroadcastType broadcastType, int instigatorId, float fastForward)
        /// </summary>
        public static readonly MethodInfo InternalTrigger = typeof(VRC_EventHandler).GetMethod(nameof(VRC_EventHandler.InternalTriggerEvent));

        /// <summary>
        /// void EmojiEvent(Player playerSending, VrcEvent event, VrcBroadcastType broadcastType, int instigatorId, float fastForward)
        /// </summary>
        public static readonly MethodInfo EmojiEvent = typeof(VRC_EventDispatcherRFC).GetMethod(
            nameof(VRC_EventDispatcherRFC.Method_Public_Void_Player_VrcEvent_VrcBroadcastType_Int32_Single_0));

        /// <summary>
        /// void SpawnEmojiRPC(int __0, Player __1)
        /// </summary>
        public static readonly MethodInfo Emoji = typeof(VRCPlayer).GetMethod(nameof(VRCPlayer.SpawnEmojiRPC));

        #endregion

        #region NetworkManager
        /// <summary>
        /// void OnLeftRoom()
        /// </summary>
        public static readonly MethodInfo LocalLeave = typeof(NetworkManager).GetMethod(nameof(NetworkManager.OnLeftRoom));
        /// <summary>
        /// void OnJoinedRoom()
        /// </summary>
        public static readonly MethodInfo LocalJoin = typeof(NetworkManager).GetMethod(nameof(NetworkManager.OnJoinedRoom));

        
        //JoinAndLeave[0] = join
        //JoinAndLeave[1] = leave
        //changes often :/
        public static readonly MethodInfo[] JoinAndLeave = typeof(NetworkManager).GetMethods().Where(m =>
         m.Name.Contains("Method_Public_Void_Player_") &&
         !m.Name.Contains("PDM")
        ).ToArray();
        #endregion
        
        #region Avatar
        
        //May break in future
        /*
        public static MethodInfo[] CalculatePerformance = typeof(AvatarPerformance).GetMethods().Where(m =>
        m.Name.Contains("_AvatarPerformanceStats_") &&
        m.Name.StartsWith("Method") && 
        m.Name.Contains("String")
        ).ToArray();
        */      
        
        /// <summary>
        /// bool AvatarLoad(ApiAvatar __0, GameObject __1)
        /// </summary>
        public static readonly MethodInfo AvatarLoad = typeof(VRCAvatarManager).GetMethod(nameof(VRCAvatarManager.Method_Private_Boolean_ApiAvatar_GameObject_0));

        /// <summary>
        /// void RunPerformanceScan(GameObject avatarObject, AvatarPerformanceStats perfStats)
        /// </summary>
        public static readonly MethodInfo CalculatePerformance = typeof(PerformanceScannerSet).GetMethod(nameof(PerformanceScannerSet.RunPerformanceScan));

        //believe is outdated
        public static MethodInfo SwitchAvatarMethod
        {
            get
            {
                if (SwitchAvatar != null) return SwitchAvatar;
                var methods = typeof(VRCPlayer).GetMethods(BindingFlags.Instance | BindingFlags.Public);
                foreach (MethodInfo methodInfo in methods)
                {
                    //only continue if the method is private, returns void, the parameter length is 1 and its bool with a default value
                    if (!methodInfo.Name.Contains("Private") || methodInfo.ReturnType != typeof(void) || methodInfo.GetParameters().Length != 1 ||
                        methodInfo.GetParameters()[0].ParameterType != typeof(bool) || !methodInfo.GetParameters()[0].HasDefaultValue) continue;
                    SwitchAvatar = methodInfo;
                    return SwitchAvatar;
                }
                return SwitchAvatar;
            }
        }

        public static MethodInfo SwitchAvatar;
        
        #endregion

        #region Menu
        /// <summary>
        /// void MenuOpen()
        /// </summary>
        public static readonly MethodInfo MenuOpen = typeof(MenuStateController).GetMethod(nameof(MenuStateController.Method_Private_Void_0));
        /// <summary>
        /// void MenuEnable()
        /// </summary>
        public static readonly MethodInfo MenuEnable = typeof(VRC.UI.Elements.QuickMenu).GetMethod(nameof(VRC.UI.Elements.QuickMenu.OnEnable)); 
        /// <summary>
        /// void MenuDisable()
        /// </summary>
        public static readonly MethodInfo MenuDisable = typeof(VRC.UI.Elements.QuickMenu).GetMethod(nameof(VRC.UI.Elements.QuickMenu.OnDisable)); 

        #endregion
        
        #region Roommanager
        
        /// <summary>
        /// bool OnWorldChange(ApiWorld apiWorld, ApiWorldInstance apiWorldInstance, string garbageString, int usuallyOne)
        /// </summary>
        public static readonly MethodInfo OnWorldChange = typeof(RoomManager).GetMethod(nameof(RoomManager.Method_Public_Static_Boolean_ApiWorld_ApiWorldInstance_String_Int32_0));
        
        #endregion
        
    }
}
