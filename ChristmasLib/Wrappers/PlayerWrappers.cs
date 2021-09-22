using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using VRC;
using VRC.Core;
using VRC.SDKBase;
using VRC.UI;

namespace ChristmasLib.Wrappers
{
    public static class PlayerWrappers
    {

        public static VRCPlayer GetCurrentPlayer() { return VRCPlayer.field_Internal_Static_VRCPlayer_0; }
        public static PlayerManager GetPlayerManager() { return PlayerManager.field_Private_Static_PlayerManager_0; }


        public static bool IsInVr() { return !VRCTrackingManager.Method_Public_Static_Boolean_9(); }


        public static int GetLocalPlayerId()
        {
            return Networking.LocalPlayer.playerId;
        }


        public static GameObject GetPlayerCamera() { return GameObject.Find("Camera (eye)"); }

    }
}
