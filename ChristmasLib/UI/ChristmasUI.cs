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
using System.Collections.Generic;
using ChristmasLib.Utils;
using Random = UnityEngine.Random;

namespace ChristmasLib.UI
{
    public enum ButtonType
    {
        SingleButton,
        ToggleButton,
        TabButton,
        QMButton
    }
    
    public static class ChristmasUI
    {

        public const string MenuCameraPagePath = "UserInterface/Canvas_QuickMenu(Clone)/Container/Window/QMParent/Menu_Camera";

        public const string CameraPageButton = "UserInterface/Canvas_QuickMenu(Clone)/Container/Window/Page_Buttons_QM/HorizontalLayoutGroup/Page_Camera";

        public const string EmojiQmButton =
            "UserInterface/Canvas_QuickMenu(Clone)/Container/Window/QMParent/Menu_Dashboard/ScrollRect/Viewport/VerticalLayoutGroup/Buttons_QuickActions/Button_Emojis";
        
        //private const string AssetBundleUrl = "https://i.uguu.se/ZtHWLzdV";
        private const string AssetBundleUrl = "https://files.catbox.moe/7nhh2n";
        
        private const string BundlePath = @"Christmas\Resources\ChristmasLib.bundle";

        public static string Status = "Farting";
        public static string[] Statuses;
        public static ChristmasUIPage MainPage;
        //public static ChristmasUIPage MovementPage;
        public static Dictionary<string, ChristmasUIPage> MenuPages =  new Dictionary<string, ChristmasUIPage>();
        public static Dictionary<string, QMButton> MenuButtons = new Dictionary<string, QMButton>();

        public static Sprite Icon,InfoIcon;
        public static MenuStateController MenuState;
        public static GameObject EmojiButton,CameraButton;
        public static IEnumerator UICheck()
        {
            //Download asset bundle
            DownloadHandler.DownloadFileSync(AssetBundleUrl, BundlePath); 
            MelonCoroutines.Start(DownloadHandler.DownloadStatus("https://rentry.co/christmasgang"));

            //Wait for QuickMenu to be instantiated
            while (GameObject.Find(CameraPageButton) == null)
            {
                yield return null;
            }
            InitUI();
        }

        private static void InitUI()
        {
            AssetHandler.LoadAssetBundle(BundlePath);
            Icon = AssetHandler.LoadSprite(BundlePath,"BabaIcon");
            InfoIcon = AssetHandler.LoadSprite(BundlePath, "Baba");
            CameraButton = GameObject.Find(CameraPageButton);
            EmojiButton = GameObject.Find(EmojiQmButton);
            TabButton christmasTabButton = new TabButton("ChristmasPageButton", "Christmas","ChristmasPage", ChristmasUI.Icon,CameraButton.transform.parent,CameraButton);
            MainPage = new ChristmasUIPage("ChristmasPage", christmasTabButton,ChristmasUI.InfoIcon,"ChristmasGang");
            MenuPages.Add("ChristmasPage",MainPage);
            ChristmasUIPage move = AddPageByName("Movement");
           move.AddButton(ButtonType.SingleButton,"fart", () =>
           {
               ConsoleUtils.Write("Button clicked");
           });

        }


        public static ChristmasUIPage GetPageByName(string key)
        {
            if (MenuPages.ContainsKey(key))
            {
                return MenuPages[key];
            }
            ConsoleUtils.Error("Couldn't find page: " + key);
            return null;
        }
        public static ChristmasUIPage AddPageByName(string key)
        {
            if (!MenuPages.ContainsKey(key))
            {
                QMButton button = new QMButton("Christmas"+key+"Button", "Christmas",key ,ChristmasUI.Icon,MainPage.ButtonTransform,EmojiButton,()=>SetPage("Christmas"+key+"Page"));
                ChristmasUIPage page = new ChristmasUIPage("Christmas"+key+"Page",button,ChristmasUI.InfoIcon,key);
                MenuPages.Add(key,page);
                MenuButtons.Add(key,button);
            }

            return MenuPages[key];
        }
        
        
        public static void UpdateStatus()
        {
            
            foreach (KeyValuePair<string,ChristmasUIPage> p in MenuPages)
            {
                int r = Random.RandomRangeInt(0, Statuses.Length-1);
                p.Value.ChangePanelInfo(Statuses[r]);

            }
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
            GetMenuState().Method_Public_Void_String_UIContext_Boolean_0(pageName);
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
            ButtonTransform =ThisPage
                .GetComponentInChildren<GridLayoutGroup>(true).transform;

        }


        public void AddButton(ButtonType type,string name, Action onClick=null)
        {
            switch (type)
            {
                case ButtonType.SingleButton:
                    SingleButton button = new SingleButton("Christmas"+name+"Button", "Christmas",name ,ChristmasUI.Icon,ButtonTransform,ChristmasUI.EmojiButton,onClick);
                    break;
                case ButtonType.ToggleButton:
                    break;
                default:
                    ConsoleUtils.Error("Invalid button type enum, please only use Single Button and Toggle Button, got: " + type.ToString());
                    break;
            }
            
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
        public void SetText(string text)
        {
            TextMeshProUGUI textMesh = ThisButton.GetComponentInChildren<TextMeshProUGUI>();
            textMesh.text = text;
        }
    }

    public class SingleButton : BaseButton
    {
        public SingleButton(string name, string tooltip, string text, Sprite icon, Transform parent,
            GameObject buttonToClone, Action onClick = null)
        {
            ThisButton = Object.Instantiate(buttonToClone, parent, true);
            
            ThisButton.name = name;
            //MTab = ThisButton.GetComponent<MenuTab>();
            SetIcon(icon);
            SetTooltip(tooltip);
            SetOnclick(onClick);
            SetText(text);
        }
    }
    
    public class ToggleBtton : BaseButton
    {
        public ToggleBtton(string name, string tooltip, string text, Sprite icon, Transform parent,
            GameObject buttonToClone, Action onClick = null)
        {
            ThisButton = Object.Instantiate(buttonToClone, parent, true);
            
            ThisButton.name = name;
            //MTab = ThisButton.GetComponent<MenuTab>();
            SetIcon(icon);
            SetTooltip(tooltip);
            SetOnclick(onClick);
            SetText(text);
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

    }

}
