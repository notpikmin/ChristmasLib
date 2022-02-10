using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChristmasLib.Asset;
using ChristmasLib.Utils;
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

        private static string AssetBundleUrl = "https://files.catbox.moe/1kzhi3.bundle";
        private static string BundlePath = @"Christmas\Resources\ChristmasLib.bundle";
        public static Texture2D Icon;
        public static Sprite IconSprite;

        public static IEnumerator UICheck()
        {
            while (VRCUiManager.prop_VRCUiManager_0 == null)
            {
                yield return null;
            }

            InitUI();
        } 
        
        public static void InitUI()
        {
            DownloadHandler.DownloadSync(AssetBundleUrl, BundlePath); 
            AssetHandler.LoadAssetBundle(BundlePath);
             Icon = AssetHandler.LoadTexture(BundlePath,"PageIcon");
             UnityEngine.Object.DontDestroyOnLoad(Icon);
             ConsoleUtils.Write(Icon.width.ToString());
             //IconSprite = Sprite.Create(Icon, new Rect(0.0f, 0.0f, Icon.width, Icon.height), new Vector2(0.5f, 0.5f), 100.0f);
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
