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
using UnityEngine.UI;
using Object = UnityEngine.Object;


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
        public static Sprite Icon;

      

        public static IEnumerator UICheck()
        {
            while (GameObject.Find(ChristmasUI.CameraPageButton) == null)
            {
                yield return null;
            }
            InitUI();
        }

        public static void InitUI()
        {
            DownloadHandler.DownloadSync(AssetBundleUrl, BundlePath); 
            AssetHandler.LoadAssetBundle(BundlePath);
            Icon = AssetHandler.LoadSprite(BundlePath,"PageIcon");
            UnityEngine.Object.DontDestroyOnLoad(Icon);

            PageButton christmasPageButton = new PageButton("ChristmasPage", "Christmas", Icon);
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
            GameObject cameraButton = GameObject.Find(ChristmasUI.CameraPageButton);
            GameObject button = Object.Instantiate(cameraButton, cameraButton.transform.parent, true);
            button.transform.FindChild("Icon").GetComponent<Image>().overrideSprite = icon;
            ThisButton = button;
        }
    }

}
