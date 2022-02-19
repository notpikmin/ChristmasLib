using System.Collections;
using System.Linq;
using ChristmasLib.Asset;
using MelonLoader;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using VRC.UI.Elements;
using VRC.UI.Elements.Controls;
using Object = UnityEngine.Object;
using System;

namespace ChristmasLib.UI
{
    public static class ChristmasUI
    {

        public const string MenuCameraPagePath = "UserInterface/Canvas_QuickMenu(Clone)/Container/Window/QMParent/Menu_Camera";

        public const string CameraPageButton = "UserInterface/Canvas_QuickMenu(Clone)/Container/Window/Page_Buttons_QM/HorizontalLayoutGroup/Page_Camera";

        public const string EmojiQmButton =
            "UserInterface/Canvas_QuickMenu(Clone)/Container/Window/QMParent/Menu_Dashboard/ScrollRect/Viewport/VerticalLayoutGroup/Buttons_QuickActions/Button_Emojis";
        
        //private const string AssetBundleUrl = "https://i.uguu.se/ZtHWLzdV";
        private const string AssetBundleUrl = "https://i.uguu.se/ZtHWLzdV";
        
        private const string BundlePath = @"Christmas\Resources\ChristmasLib.bundle";

        public static string Status = "Farting";

        public static ChristmasUIPage MainPage;
        public static ChristmasUIPage MovementPage;

        public static MenuStateController MenuState;
        
        public static IEnumerator UICheck()
        {
            //Download asset bundle
            DownloadHandler.DownloadFileSync(AssetBundleUrl, BundlePath); 
            //Wait for QuickMenu to be instantiated
            while (GameObject.Find(ChristmasUI.CameraPageButton) == null)
            {
                yield return null;
            }
            InitUI();
        }

        private static void InitUI()
        {
            AssetHandler.LoadAssetBundle(BundlePath);
            Sprite icon = AssetHandler.LoadSprite(BundlePath,"BabaIcon");
            Sprite infoIcon = AssetHandler.LoadSprite(BundlePath, "Baba");
            GameObject cameraButton = GameObject.Find(ChristmasUI.CameraPageButton);
            TabButton christmasTabButton = new TabButton("ChristmasPageButton", "Christmas","ChristmasPage", icon,cameraButton.transform.parent,cameraButton);
            MainPage = new ChristmasUIPage("ChristmasPage", christmasTabButton,infoIcon,"ChristmasGang");
            GameObject emojiButton = GameObject.Find(EmojiQmButton);
            QMButton christmasMovementButton = new QMButton("ChristmasMovementButton", "Christmas","Movement" ,icon,MainPage.ButtonTransform,emojiButton,()=>SetPage("ChristmasMovementPage"));
            MovementPage = new ChristmasUIPage("ChristmasMovementPage", christmasTabButton,infoIcon,"Movement");

            
        }

        
        public static void UpdateStatus()
        {
            MelonCoroutines.Start(DownloadHandler.DownloadStatus("https://rentry.co/christmasgang"));
        }


        public static MenuStateController GetMenuState()
        {
            if (MenuState == null)
            {
                MenuState = GameObject.Find("UserInterface/Canvas_QuickMenu(Clone)")
                    .GetComponent<MenuStateController>();
            }

            return MenuState;

        }

        public static void SetPage(string pageName)
        {
            GetMenuState().Method_Public_Void_String_UIContext_Boolean_0(pageName,null,false);
        }
        
        
    }
    
    
    public class ChristmasUIPage
    {
        public GameObject ThisPage;
        public UIPage ChristmasUiPage;
        public Transform ButtonTransform;
        public ChristmasUIPage(string name, BaseButton button,Sprite infoIcon,string header)
        {
            
            GameObject foundPage = GameObject.Find(ChristmasUI.MenuCameraPagePath);
            ThisPage =  Object.Instantiate(foundPage, foundPage.transform.parent, true);
            
            ThisPage.name = name;
            
            Object.Destroy(ThisPage.GetComponent<VRCUiPage>());
            ChristmasUiPage = ThisPage.AddComponent<UIPage>();
            ChristmasUiPage.field_Public_String_0 = name;
            ChristmasUiPage.field_Private_MenuStateController_0 = ChristmasUI.GetMenuState();
            ChristmasUiPage.field_Private_List_1_UIPage_0.Add(ChristmasUiPage);
            ChristmasUiPage.field_Public_Boolean_0 = true;
            AddToDictionary(button,name);
            ChangePanelInfo(ChristmasUI.Status, infoIcon);
            SetHeader(header);
            RemoveButtons();
//need a better way of doing this
            ButtonTransform = GameObject
                .Find("UserInterface/Canvas_QuickMenu(Clone)/Container/Window/QMParent/ChristmasPage")
                .GetComponentInChildren<GridLayoutGroup>(true).transform;

        }

 
        
        public void SetHeader(string text)
        {
            GameObject header = ThisPage.transform.FindChild("Header_Camera").gameObject;
            if (header != null)
            {
                TextMeshProUGUI textMesh = header.GetComponentInChildren<TextMeshProUGUI>();
                textMesh.text = text;
            }
        }

        public void AddToDictionary(BaseButton tabButton, string pageName)
        {
            MenuStateController menuStateController = ChristmasUI.GetMenuState();
            menuStateController.field_Private_Dictionary_2_String_UIPage_0.Add(pageName,ChristmasUiPage);
            menuStateController.field_Public_ArrayOf_UIPage_0 = menuStateController.field_Public_ArrayOf_UIPage_0.Append(ChristmasUiPage).ToArray();

        }
        
        //not working
        public void RemoveButtons()
        {
            //  Transform buttonParent = GameObject.Find().transform;
            //Transform parent = thisPage.transform.Find(ChristmasUI.MenuCameraPageButtonsParent);
            Button[] buttons = ThisPage.GetComponentsInChildren<Button>(true);
            foreach (Button b in buttons)
            {
               Object.Destroy(b.gameObject);
               //b.gameObject.SetActive(false);

            }
            Toggle[] toggles = ThisPage.GetComponentsInChildren<Toggle>(true);
            foreach (Toggle t in toggles)
            {
                Object.Destroy(t.gameObject);
                //t.gameObject.SetActive(false);

            }
        }

        public void ChangePanelInfo(string text, Sprite sprite =null)
        {
            GameObject panelInfo = ThisPage.transform.FindChild("Panel_Info").gameObject;
            TextMeshProUGUI textMesh = panelInfo.GetComponentInChildren<TextMeshProUGUI>();
            textMesh.text = text;
            if (sprite != null)
            {
                RawImage rawImage = panelInfo.GetComponentInChildren<RawImage>();
                rawImage.m_Texture = sprite.texture;
            }
        }
        
    }

    public class BaseButton
    {
        public GameObject ThisButton;
        
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

        public void SetOnclick(Action onClick)
        {
            ThisButton.GetComponent<Button>().onClick.AddListener(onClick);
        }
        
    }

    public class QMButton : BaseButton
    {
        public QMButton(string name, string tooltip,string text, Sprite icon, Transform parent, GameObject buttonToClone,Action onClick = null)
        {
            ThisButton = Object.Instantiate(buttonToClone, parent, true);
            
            ThisButton.name = name;
            //MTab = ThisButton.GetComponent<MenuTab>();
            SetIcon(icon);
            SetTooltip(tooltip);
            SetOnclick(onClick);
            SetText(text);
        }

        public void SetText(string text)
        {
            TextMeshProUGUI textMesh = ThisButton.GetComponentInChildren<TextMeshProUGUI>();
            textMesh.text = text;
        }
    }
    
    public class TabButton :BaseButton
    {
        public MenuTab MTab;

        public TabButton(string name, string tooltip,string pageName, Sprite icon, Transform parent, GameObject buttonToClone)

        {


            ThisButton = Object.Instantiate(buttonToClone, parent, true);


            ThisButton.name = name;
            MTab = ThisButton.GetComponent<MenuTab>();
            MTab.field_Public_String_0 = pageName;

            SetIcon(icon);
            SetTooltip(tooltip);
        }
        
          public MenuStateController GetMenuStateController()
          {
             return MTab.field_Private_MenuStateController_0;
          }
          
    }

}
