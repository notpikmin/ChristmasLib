using UnityEngine;
using VRC;
using VRC.SDKBase;

namespace ChristmasLib.Wrappers
{
    public static class PlayerWrappers
    {

        public static VRCPlayer GetCurrentPlayer()
        {
            return VRCPlayer.field_Internal_Static_VRCPlayer_0;
        }
        public static PlayerManager GetPlayerManager()
        {
            return PlayerManager.field_Private_Static_PlayerManager_0;
        }


        public static bool IsInVr()
        {
            return !VRCTrackingManager.Method_Public_Static_Boolean_9();
        }

        public static VRCPlayerApi GetLocalPlayerApi()
        {
            return Networking.LocalPlayer;
        }

        public static int GetLocalPlayerId()
        {
            return GetLocalPlayerApi().playerId;
        }

        public static GameObject GetPlayerCamera()
        {
            return GameObject.Find("Camera (eye)");
        }
    }
}