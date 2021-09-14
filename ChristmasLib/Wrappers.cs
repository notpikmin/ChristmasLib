using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using VRC;
using VRC.Core;
using VRC.SDKBase;

namespace ChristmasLib
{
   public static class Wrappers
    {


        public static PlayerManager GetPlayerManager() { return PlayerManager.field_Private_Static_PlayerManager_0; }
        public static QuickMenu GetQuickMenu() { return QuickMenu.prop_QuickMenu_0; }

        public static VRCUiManager GetVRCUiPageManager() { return VRCUiManager.prop_VRCUiManager_0; }

        public static UserInteractMenu GetUserInteractMenu() { return Resources.FindObjectsOfTypeAll<UserInteractMenu>()[0]; }

        public static GameObject GetPlayerCamera() { return GameObject.Find("Camera (eye)"); }



        public static VRCVrCamera GetVRCVrCamera()
        {
            return VRCVrCamera.field_Private_Static_VRCVrCamera_0;

        }

        public static string GetRoomId() { return APIUser.CurrentUser.location; }

        public static VRCUiManager GetVRCUiManager() { return VRCUiManager.prop_VRCUiManager_0; }

        public static HighlightsFX GetHighlightsFX() { return HighlightsFX.prop_HighlightsFX_0; }

        public static void EnableOutline(this HighlightsFX instance, Renderer renderer, bool state) => instance.Method_Public_Void_Renderer_Boolean_0(renderer, state); //First method to take renderer, bool parameters

        public static VRCUiPopupManager GetVRCUiPopupManager() { return VRCUiPopupManager.prop_VRCUiPopupManager_0; }

        public static void AlertPopup(this VRCUiPopupManager manager, string title, string text) => manager.Method_Public_Void_String_String_Single_0(title, text, 10f);


        public static void AlertV2(string title, string Content, string buttonname, Action action, string button2, Action action2) => VRCUiPopupManager.field_Private_Static_VRCUiPopupManager_0.Method_Public_Void_String_String_String_Action_String_Action_Action_1_VRCUiPopup_0(title, Content, buttonname, action, button2, action2, null);

        public static bool IsInVr() { return !VRCTrackingManager.Method_Public_Static_Boolean_9(); }




        public static VRCPlayer GetCurrentPlayer() { return VRCPlayer.field_Internal_Static_VRCPlayer_0; }

        public static Player[] GetAllPlayers(this PlayerManager instance) { return instance.prop_ArrayOf_Player_0; }

        public static APIUser GetAPIUser(this Player player) { return player.prop_APIUser_0; }

        public static ApiAvatar GetAPIAvatar(this VRCPlayer player) { return player.prop_ApiAvatar_0; }

        public static Player GetVRC_Player(this VRCPlayer player) { return player.prop_Player_0; }

        public static VRCPlayer GetVRCPlayer(this Player player) { return player.prop_VRCPlayer_0; }

        public static VRC.SDKBase.VRCPlayerApi GetVRCPlayerApi(this Player player) { return player.prop_VRCPlayerApi_0; }



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



    }
}
