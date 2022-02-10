using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChristmasLib.Asset;
using MelonLoader;
using UnityEngine;


namespace ChristmasLib.UI
{
    public static class ChristmasUI
    {
        public static string MenuDashboardPagePath = "UserInterface/Canvas_QuickMenu(Clone)/Container/Window/QMParent/Menu_Dashboard";
        public static string MenuCameraPagePath = "UserInterface/Canvas_QuickMenu(Clone)/Container/Window/QMParent/Menu_Camera";
        public static string DashboardHeaderPath = "UserInterface/Canvas_QuickMenu(Clone)/Container/Window/QMParent/Menu_Dashboard/ScrollRect/Viewport/VerticalLayoutGroup/Header_QuickActions";
        public static string DashboardButtonGroupPath = "UserInterface/Canvas_QuickMenu(Clone)/Container/Window/QMParent/Menu_Dashboard/ScrollRect/Viewport/VerticalLayoutGroup/Buttons_QuickActions";
        public static string DashboardButtonPath = "UserInterface/Canvas_QuickMenu(Clone)/Container/Window/QMParent/Menu_Dashboard/ScrollRect/Viewport/VerticalLayoutGroup/Buttons_QuickActions/Button_GoHome";

        public static string CameraPageButton = "UserInterface/Canvas_QuickMenu(Clone)/Container/Window/Page_Buttons_QM/HorizontalLayoutGroup/Page_Camera";

        private static string AssetBundleUrl = "https://cdn.discordapp.com/attachments/941141744970498051/941141772099276800/christmaslib.bundle";

        public static void InitUI()
        {
            DownloadHandler.DownloadSync(AssetBundleUrl, @"Christmas\Resources\ChristmasLib.bundle");
        }
        
    }

    public class BaseButton
    {
        protected GameObject ThisButton;
        protected string Name;
        protected string Tooltip;
        protected Sprite Icon;
    
    }
    
    
    public class PageButton : BaseButton
    {
        public PageButton(string name, string tooltip, Sprite icon)
        {
            Name = name;
            Tooltip = tooltip;
            Icon = icon;
        }
    }

}
