using ChristmasLib.Extensions;
using System;
using UnityEngine;
using VRC;
using VRC.UI;
using VRC.UI.Elements;

namespace ChristmasLib.Wrappers
{
   public static class UiWrappers
    {

        #region Quick Menu
        public static QuickMenu GetQuickMenu() { return QuickMenu.prop_QuickMenu_0; }

        public static UserInteractMenu GetUserInteractMenu() { return Resources.FindObjectsOfTypeAll<UserInteractMenu>()[0]; }

        public static VRCUiManager GetVrcUiManager() { return VRCUiManager.prop_VRCUiManager_0; }
        #endregion

        #region ESP
        public static HighlightsFX GetHighlightsFX() { return HighlightsFX.prop_HighlightsFX_0; }

        public static void EnableOutline(this HighlightsFX instance, Renderer renderer, bool state) => instance.Method_Public_Void_Renderer_Boolean_0(renderer, state); //First method to take renderer, bool parameters
        #endregion

        #region Popup
        public static VRCUiPopupManager GetVrcUiPopupManager() { return VRCUiPopupManager.prop_VRCUiPopupManager_0; }

        public static void AlertPopup(this VRCUiPopupManager manager, string title, string text) => manager.Method_Public_Void_String_String_Single_0(title, text, 10f);

        public static void AlertV2(string title, string content, string buttonName, Action action, string button2, Action action2) => VRCUiPopupManager.field_Private_Static_VRCUiPopupManager_0.Method_Public_Void_String_String_String_Action_String_Action_Action_1_VRCUiPopup_0(title, content, buttonName, action, button2, action2);

        #endregion

        #region NewUI

        public static VRCUiManager GetVrcUiPageManager() { return VRCUiManager.prop_VRCUiManager_0; }

        public static UIManagerImpl GetUIManagerImpl() { return UIManagerImpl.prop_UIManagerImpl_0; }



   
        public static MenuController GetMenuController()
        {
            return GetUIManagerImpl().field_Public_MenuController_0;
        }

        public static VRCPlayer GetSelectedVrcPlayer()
        {
            return GetMenuController().activePlayer;
        }

        public static Player GetSelectedPlayer()
        {
            return GetSelectedVrcPlayer().GetVRC_Player();
        }
        #endregion

    }
}
