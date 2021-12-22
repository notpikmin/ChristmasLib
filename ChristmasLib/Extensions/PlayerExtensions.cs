﻿using ChristmasLib.Wrappers;
using Il2CppSystem.Collections;
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

namespace ChristmasLib.Extensions
{
    public static class PlayerExtensions
    {
        #region PlayerManager
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
        public static ApiAvatar GetAPIAvatar(this VRCPlayer player) { return player.prop_ApiAvatar_0; }
        public static Player GetVRC_Player(this VRCPlayer player) { return player.prop_Player_0; }
        #endregion

        #region Player

        public static APIUser GetAPIUser(this Player player) { return player.prop_APIUser_0; }
        public static VRCPlayer GetVRCPlayer(this Player player) { return player.prop_VRCPlayer_0; }
        public static VRCPlayerApi GetVRCPlayerApi(this Player player) { return player.prop_VRCPlayerApi_0; }

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

        public static bool IsLocalPlayer(this Player player){ return player.GetAPIUser().id == APIUser.CurrentUser.id;}
        #endregion

        #region Photon Player
        public static Hashtable GetPhotonHashTable(this Photon.Realtime.Player player) { return player.prop_Hashtable_0; }

        public static bool IsVR(this Photon.Realtime.Player player){return player.GetPhotonHashTable()["inVRMode"].Unbox<bool>();}

        public static bool IsHidingTrust(this Photon.Realtime.Player player) { return player.GetPhotonHashTable()["showSocialRank"].Unbox<bool>(); }
        public static Int32 GetAvatarEyeHeight(this Photon.Realtime.Player player) { return player.GetPhotonHashTable()["avatarEyeHeight"].Unbox<Int32>(); }

        
        #endregion

        #region Select
        public static Player GetSelectedPlayer(this QuickMenu instance)
        {
            var APIUser = instance.prop_APIUser_0;
            var playerManager = PlayerWrappers.GetPlayerManager();
            return playerManager.GetPlayer(APIUser.id);
        }

        public static Player GetPlayerByRayCast(this RaycastHit RayCast)
        {
            var gameObject = RayCast.transform.gameObject;
            return GetPlayer(PlayerWrappers.GetPlayerManager(), VRCPlayerApi.GetPlayerByGameObject(gameObject).playerId);
        }
        #endregion

    }
}
