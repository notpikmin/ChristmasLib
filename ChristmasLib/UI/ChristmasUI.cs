using System.Collections;
using System.Linq;
using ChristmasLib.Asset;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using VRC.UI.Elements;
using VRC.UI.Elements.Controls;
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
        
        
        //private const string AssetBundleUrl = "https://files.catbox.moe/1kzhi3.bundle";
        private const string AssetBundleUrl = "https://i.uguu.se/qQOwcGEk.bundle";
        
        private const string BundlePath = @"Christmas\Resources\ChristmasLib.bundle";
       
        
        public static Sprite _icon;

      

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
            PageButton christmasPageButton = new PageButton("ChristmasPageButton", "Christmas", _icon);
            Page christmasPage = new Page("ChristmasPage", christmasPageButton);

        }

        
       
    }
    
    
    public class Page
    {
        public GameObject thisPage;
        public UIPage christmasUiPage;
        public Page(string name, PageButton button)
        {
            
            GameObject foundPage = GameObject.Find(ChristmasUI.MenuCameraPagePath);
            thisPage =  Object.Instantiate(foundPage, foundPage.transform.parent, true);
            
            thisPage.name = name;
            
            Object.Destroy(thisPage.GetComponent<VRCUiPage>());
            christmasUiPage = thisPage.AddComponent<UIPage>();
            christmasUiPage.field_Public_String_0 = name;
            button.MTab.field_Public_String_0 = name;
            christmasUiPage.field_Private_MenuStateController_0 = button.GetMenuStateController();
            christmasUiPage.field_Private_List_1_UIPage_0.Add(christmasUiPage);
            christmasUiPage.field_Public_Boolean_0 = true;
            RemoveButtons();
            AddToDictionary(button,name);
            ChangePanelInfo("I Farted", ChristmasUI._icon);
            SetHeader("Christmas Gang");
        }

        public void SetHeader(string text)
        {
            GameObject header = thisPage.transform.FindChild("Header_Camera").gameObject;
            if (header != null)
            {
                TextMeshProUGUI textMesh = header.GetComponentInChildren<TextMeshProUGUI>();
                textMesh.text = text;
            }
        }

        public void AddToDictionary(PageButton pageButton, string pageName)
        {
            MenuStateController menuStateController = pageButton.GetMenuStateController();
            menuStateController.field_Private_Dictionary_2_String_UIPage_0.Add(pageName,christmasUiPage);
            menuStateController.field_Public_ArrayOf_UIPage_0 = menuStateController.field_Public_ArrayOf_UIPage_0.Append(christmasUiPage).ToArray();

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
            Toggle[] toggles = thisPage.GetComponentsInChildren<Toggle>(true);
            foreach (Toggle t in toggles)
            {
                Object.Destroy(t.gameObject);
            }
        }

        public void ChangePanelInfo(string text, Sprite sprite =null)
        {
            GameObject panelInfo = thisPage.transform.FindChild("Panel_Info").gameObject;
            TextMeshProUGUI textMesh = panelInfo.GetComponentInChildren<TextMeshProUGUI>();
            textMesh.text = text;
            if (sprite != null)
            {
                RawImage rawImage = panelInfo.GetComponentInChildren<RawImage>();
                rawImage.m_Texture = sprite.texture;
            }
        }
        
    }
    
    public class PageButton 
    {
        public GameObject ThisButton;
        public MenuTab MTab;
        public PageButton(string name, string tooltip, Sprite icon)
        {
         
            GameObject cameraButton = GameObject.Find(ChristmasUI.CameraPageButton);
            ThisButton = Object.Instantiate(cameraButton, cameraButton.transform.parent, true);;

            
            ThisButton.name = name;
            MTab = ThisButton.GetComponent<MenuTab>();
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
        
        
        public MenuStateController GetMenuStateController()
        {
           return MTab.field_Private_MenuStateController_0;
        }
        
    }

}
