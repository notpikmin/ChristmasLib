using ChristmasLib.Wrappers;
using Il2CppSystem.Collections;
using System;
using System.Linq;
using UnityEngine;
using VRC;
using VRC.Core;
using VRC.SDKBase;
using VRC.UI;

namespace ChristmasLib.Extensions
{
    public static class PlayerExtensions
    {
        #region PlayerManager
        public static Player[] GetAllPlayers(this PlayerManager instance) { return instance.prop_ArrayOf_Player_0; }

        public static Player GetPlayer(this PlayerManager instance, string userID)
        {
            var players = instance.GetAllPlayers();
            //get the first player in all players that's id matches the parameters id
            //not sure of the return value if its default?
            return players.FirstOrDefault(player => player.GetAPIUser().id == userID);
        }

        public static Player GetPlayerByName(this PlayerManager instance, string name)
        {
            var players = instance.GetAllPlayers();
            //get the first player in all players that's display name matches the parameters name
            return players.FirstOrDefault(player => player.GetAPIUser().displayName.ToLower().Contains(name.ToLower()));
        }

        public static Player GetPlayerByPlayerID(this PlayerManager instance, int index)
        {
            var players = instance.GetAllPlayers();
            //get the first player in all players that's playerIDS matches the parameters ID
            return players.FirstOrDefault(player => player.GetVrcPlayerApi().playerId == index);
        }

        public static Player GetPlayer(this PlayerManager instance, VRCPlayerApi api)
        {
            var players = instance.GetAllPlayers();
            foreach (var player in players)
            {
                if (player.GetVrcPlayerApi().playerId == api.playerId)
                {
                    return player;
                }
            }
            return null;
        }
        #endregion

        #region VRCPlayer
        public static ApiAvatar GetAPIAvatar(this VRCPlayer player) { return player.prop_ApiAvatar_0; }
        public static Player GetVRC_Player(this VRCPlayer player) { return player.prop_Player_0; }
        #endregion

        #region Player

        public static ApiAvatar GetAPIAvatar(this Player player){ return player.prop_ApiAvatar_0;}
        public static APIUser GetAPIUser(this Player player) { return player.prop_APIUser_0; }
        public static VRCPlayer GetVrcPlayer(this Player player) { return player.prop_VRCPlayer_0; }
        public static VRCPlayerApi GetVrcPlayerApi(this Player player) { return player.prop_VRCPlayerApi_0; }

        public static PlayerNet GetPlayerNet(this Player player) { return player.prop_PlayerNet_0; }
        
        public static Photon.Realtime.Player GetPhotonPlayer(this Player player) { return player.prop_Player_1; }

        public static bool IsQuest(this Player player) { return player.GetAPIUser().IsOnMobile; }

        public static PageUserInfo GetPageUserInfo(this Player player)
        {
            PageUserInfo component = GameObject.Find("Screens").transform.Find("UserInfo").GetComponent<PageUserInfo>();
            component.field_Private_APIUser_0 = new APIUser
            {
                id = player.GetAPIUser().id
            };
            return component;
        }

        public static void ToggleMute(this Player player)
        {
            PageUserInfo pageUserInfo = player.GetPageUserInfo();
            if (!player.IsLocalPlayer())
            {
                pageUserInfo.ToggleMute();
            }

        }

        public static void ToggleBlock(this Player player)
        {
            PageUserInfo pageUserInfo = player.GetPageUserInfo();
            if (!player.IsLocalPlayer())
            {
                pageUserInfo.ToggleBlock();
            }

        }
        public static bool IsLocalPlayer(this Player player){ return player.GetAPIUser().id == APIUser.CurrentUser.id;}
        #endregion

        #region Photon Player
        public static Hashtable GetPhotonHashTable(this Photon.Realtime.Player player) { return player.prop_Hashtable_0; }

        public static bool IsVR(this Photon.Realtime.Player player){return player.GetPhotonHashTable()["inVRMode"].Unbox<bool>();}

        public static bool IsHidingTrust(this Photon.Realtime.Player player) { return player.GetPhotonHashTable()["showSocialRank"].Unbox<bool>(); }
        public static int GetAvatarEyeHeight(this Photon.Realtime.Player player) { return player.GetPhotonHashTable()["avatarEyeHeight"].Unbox<int>(); }

        
        #endregion

        #region Select
        public static Player GetSelectedPlayer(this QuickMenu instance)
        {
            var apiUser = instance.prop_APIUser_0;
            var playerManager = PlayerWrappers.GetPlayerManager();
            return playerManager.GetPlayer(apiUser.id);
        }

        public static Player GetPlayerByRayCast(this RaycastHit rayCast)
        {
            var gameObject = rayCast.transform.gameObject;
            return GetPlayerByPlayerID(PlayerWrappers.GetPlayerManager(), VRCPlayerApi.GetPlayerByGameObject(gameObject).playerId);
        }
        #endregion

    }
}
