using ChristmasLib.Extensions;
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

namespace ChristmasLib
{
   public static class UiWrappers
    {

        #region Quick Menu
        public static QuickMenu GetQuickMenu() { return QuickMenu.prop_QuickMenu_0; }

        public static UserInteractMenu GetUserInteractMenu() { return Resources.FindObjectsOfTypeAll<UserInteractMenu>()[0]; }

        public static VRCUiManager GetVRCUiManager() { return VRCUiManager.prop_VRCUiManager_0; }
        #endregion

        #region ESP
        public static HighlightsFX GetHighlightsFX() { return HighlightsFX.prop_HighlightsFX_0; }

        public static void EnableOutline(this HighlightsFX instance, Renderer renderer, bool state) => instance.Method_Public_Void_Renderer_Boolean_0(renderer, state); //First method to take renderer, bool parameters
        #endregion

        #region Popup
        public static VRCUiPopupManager GetVRCUiPopupManager() { return VRCUiPopupManager.prop_VRCUiPopupManager_0; }

        public static void AlertPopup(this VRCUiPopupManager manager, string title, string text) => manager.Method_Public_Void_String_String_Single_0(title, text, 10f);

        public static void AlertV2(string title, string content, string buttonname, Action action, string button2, Action action2) => VRCUiPopupManager.field_Private_Static_VRCUiPopupManager_0.Method_Public_Void_String_String_String_Action_String_Action_Action_1_VRCUiPopup_0(title, content, buttonname, action, button2, action2, null);

        #endregion

        #region newUI

        public static VRCUiManager GetVRCUiPageManager() { return VRCUiManager.prop_VRCUiManager_0; }

        public static UIManagerImpl GetUIManagerImpl() { return UIManagerImpl.prop_UIManagerImpl_0; }



        public static MenuController GetMenuController()
        {
            return GetUIManagerImpl().field_Public_MenuController_0;
        }

        public static VRCPlayer GetSelectedVRCPlayer()
        {
            return GetMenuController().activePlayer;
        }

        public static VRC.Player GetSelectedPlayer()
        {
            return GetSelectedVRCPlayer().GetVRC_Player();
        }
        #endregion

    }
}
