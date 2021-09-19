using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using VRC;
using VRC.Core;
using VRC.SDKBase;

namespace ChristmasLib.Wrappers
{
    public static class PlayerWrappers
    {
        #region PlayerManager
        public static PlayerManager GetPlayerManager() { return PlayerManager.field_Private_Static_PlayerManager_0; }
        public static Player[] GetAllPlayers(this PlayerManager instance) { return instance.prop_ArrayOf_Player_0; }

        public static Player GetPlayer(this PlayerManager instance, string UserID)
        {
            var Players = instance.GetAllPlayers();
            for (int i = 0; i < Players.Length; i++)
            {
                var player = Players[i];
                if (player.GetAPIUser().id == UserID)
                {
                    return player;
                }
            }
            return null;
        }

        public static Player GetPlayerByName(this PlayerManager instance, string Name)
        {
            var Players = instance.GetAllPlayers();
            for (int i = 0; i < Players.Length; i++)
            {
                var player = Players[i];
                if (player.GetAPIUser().displayName.ToLower().Contains(Name.ToLower()))
                {
                    return player;
                }
            }
            return null;
        }

        public static Player GetPlayer(this PlayerManager instance, int Index)
        {
            var Players = instance.GetAllPlayers();
            for (int i = 0; i < Players.Length; i++)
            {
                var player = Players[i];
                if (player.GetVRCPlayerApi().playerId == Index)
                {
                    return player;
                }
            }
            return null;
        }

        public static Player GetPlayer(this PlayerManager instance, VRCPlayerApi api)
        {
            var Players = instance.GetAllPlayers();
            for (int i = 0; i < Players.Length; i++)
            {
                var player = Players[i];
                if (player.GetVRCPlayerApi().playerId == api.playerId)
                {
                    return player;
                }
            }
            return null;
        }
        #endregion

        #region VRCPlayer
        public static VRCPlayer GetCurrentPlayer() { return VRCPlayer.field_Internal_Static_VRCPlayer_0; }
        public static ApiAvatar GetAPIAvatar(this VRCPlayer player) { return player.prop_ApiAvatar_0; }
        public static Player GetVRC_Player(this VRCPlayer player) { return player.prop_Player_0; }
        #endregion

        #region Player
        public static APIUser GetAPIUser(this Player player) { return player.prop_APIUser_0; }
        public static VRCPlayer GetVRCPlayer(this Player player) { return player.prop_VRCPlayer_0; }
        public static VRCPlayerApi GetVRCPlayerApi(this Player player) { return player.prop_VRCPlayerApi_0; }
        #endregion

        #region Select
        public static Player GetSelectedPlayer(this QuickMenu instance)
        {
            var APIUser = instance.prop_APIUser_0;
            var playerManager = GetPlayerManager();
            return playerManager.GetPlayer(APIUser.id);
        }

        public static Player GetPlayerByRayCast(this RaycastHit RayCast)
        {
            var gameObject = RayCast.transform.gameObject;
            return GetPlayer(GetPlayerManager(), VRCPlayerApi.GetPlayerByGameObject(gameObject).playerId);
        }
        #endregion

        public static bool IsInVr() { return !VRCTrackingManager.Method_Public_Static_Boolean_9(); }


        public static int GetLocalPlayerId()
        {
            return Networking.LocalPlayer.playerId;
        }


        public static GameObject GetPlayerCamera() { return GameObject.Find("Camera (eye)"); }

    }
}
