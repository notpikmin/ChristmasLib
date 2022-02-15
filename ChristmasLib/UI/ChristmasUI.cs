using System.Collections;
using ChristmasLib.Asset;
using UnityEngine;
using UnityEngine.UI;
using Object = UnityEngine.Object;


namespace ChristmasLib.UI
{
    public static class ChristmasUI
    {
        public const string MenuDashboardPagePath = "UserInterface/Canvas_QuickMenu(Clone)/Container/Window/QMParent/Menu_Dashboard";
        public const string DashboardHeaderPath = "UserInterface/Canvas_QuickMenu(Clone)/Container/Window/QMParent/Menu_Dashboard/ScrollRect/Viewport/VerticalLayoutGroup/Header_QuickActions";
        public const string DashboardButtonGroupPath = "UserInterface/Canvas_QuickMenu(Clone)/Container/Window/QMParent/Menu_Dashboard/ScrollRect/Viewport/VerticalLayoutGroup/Buttons_QuickActions";
        public const string DashboardButtonPath = "UserInterface/Canvas_QuickMenu(Clone)/Container/Window/QMParent/Menu_Dashboard/ScrollRect/Viewport/VerticalLayoutGroup/Buttons_QuickActions/Button_GoHome";

        public const string MenuCameraPageButtonsParent = "Scrollrect/Viewport/VerticalLayoutGroup/Buttons";
        public const string MenuCameraPagePath = "UserInterface/Canvas_QuickMenu(Clone)/Container/Window/QMParent/Menu_Camera";

        public const string CameraPageButton = "UserInterface/Canvas_QuickMenu(Clone)/Container/Window/Page_Buttons_QM/HorizontalLayoutGroup/Page_Camera";
        
        
        private const string AssetBundleUrl = "https://files.catbox.moe/1kzhi3.bundle";
        private const string BundlePath = @"Christmas\Resources\ChristmasLib.bundle";
       
        
        private static Sprite _icon;

      

        public static IEnumerator UICheck()
        {
            //Download asset bundle
            DownloadHandler.DownloadSync(AssetBundleUrl, BundlePath); 
            //Wait for QuickMenu to be instantiated to be found
            while (GameObject.Find(ChristmasUI.CameraPageButton) == null)
            {
                yield return null;
            }
            InitUI();
        }

        private static void InitUI()
        {
            AssetHandler.LoadAssetBundle(BundlePath);
            _icon = AssetHandler.LoadSprite(BundlePath,"PageIcon");
            UnityEngine.Object.DontDestroyOnLoad(_icon);
            Page christmasPage = new Page("ChristmasPage");
            PageButton christmasPageButton = new PageButton("ChristmasPageButton", "Christmas", _icon);
            
        }
        
       
    }
    

    public class Page
    {
        public GameObject thisPage;
        public Page(string name)
        {
            
            GameObject foundPage = GameObject.Find(ChristmasUI.MenuCameraPagePath);
            thisPage =  Object.Instantiate(foundPage, foundPage.transform.parent, true);
            
            thisPage.name = name;
            
            Object.Destroy(thisPage.GetComponent<VRCUiPage>());
            VRCUiPage christmasUiPage = thisPage.AddComponent<VRCUiPage>();
            RemoveButtons();
        }

        
        //not working
        public void RemoveButtons()
        {
            //  Transform buttonParent = GameObject.Find().transform;
            //Transform parent = thisPage.transform.Find(ChristmasUI.MenuCameraPageButtonsParent);
            Button[] buttons = thisPage.GetComponentsInChildren<Button>(true);
            foreach (Button b in buttons)
            {
               Object.Destroy(b.gameObject);
            }
            
        }
        
    }
    
    public class PageButton 
    {
        public GameObject ThisButton;
        public PageButton(string name, string tooltip, Sprite icon)
        {
         
            GameObject cameraButton = GameObject.Find(ChristmasUI.CameraPageButton);
            ThisButton = Object.Instantiate(cameraButton, cameraButton.transform.parent, true);;

            
            ThisButton.name = name;

            SetIcon(icon);
            SetTooltip(tooltip);
        }


        public void SetIcon(Sprite icon)
        {
            ThisButton.transform.FindChild("Icon").GetComponent<Image>().overrideSprite = icon;
        }
        
        public void SetTooltip(string text)
        {
            if (ThisButton != null)
            {
                ThisButton.GetComponent<VRC.UI.Elements.Tooltips.UiTooltip>().field_Public_String_0 = text;
            }
        }
        
    }

}
