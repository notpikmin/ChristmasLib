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
        ToggleButton
    }

    public static class ChristmasUI
    {
        #region Parameters

        public const string MenuCameraPagePath =
            "UserInterface/Canvas_QuickMenu(Clone)/Container/Window/QMParent/Menu_Camera";

        public const string CameraPageButton =
            "UserInterface/Canvas_QuickMenu(Clone)/Container/Window/Page_Buttons_QM/HorizontalLayoutGroup/Page_Camera";

        public const string ToggleButtonPath =
            "UserInterface/Canvas_QuickMenu(Clone)/Container/Window/QMParent/Menu_Settings/Panel_QM_ScrollRect/Viewport/VerticalLayoutGroup/Buttons_UI_Elements_Row_1/Button_ToggleQMInfo";

        public const string EmojiQmButton =
            "UserInterface/Canvas_QuickMenu(Clone)/Container/Window/QMParent/Menu_Dashboard/ScrollRect/Viewport/VerticalLayoutGroup/Buttons_QuickActions/Button_Emojis";

        public const string UserPagePath =
            "UserInterface/Canvas_QuickMenu(Clone)/Container/Window/QMParent/Menu_SelectedUser_Local/ScrollRect/Viewport/VerticalLayoutGroup/Buttons_UserActions";

        //private const string AssetBundleUrl = "https://i.uguu.se/ZtHWLzdV";
        private const string AssetBundleUrl = "https://files.catbox.moe/7nhh2n";

        private const string BundlePath = @"Christmas\Resources\ChristmasLib.bundle";

        


        
        // TODO move non api util things out into its own class
        public static ChristmasUIPage MainPage, UserPage;
        
        //public static ChristmasUIPage MovementPage;
        public static Dictionary<string, ChristmasUIPage> MenuPages = new Dictionary<string, ChristmasUIPage>();
        public static Dictionary<string, QMButton> MenuButtons = new Dictionary<string, QMButton>();

        public static Sprite Icon, InfoIcon;
        public static MenuStateController MenuState;
        public static GameObject EmojiButton, CameraButton, QmToggleButton, SelectUserButtonParent;

        public static List<Action> OnUiInitActions = new List<Action>();

        #endregion

        #region InitUI

        public static IEnumerator UICheck()
        {
            //Download asset bundle
            DownloadHandler.DownloadFileSync(AssetBundleUrl, BundlePath);
            MelonCoroutines.Start(StatusHandler.DownloadStatus());
            //TODO optimize to a patch maybe?
            //Wait for QuickMenu to be instantiated
            while (GameObject.Find(CameraPageButton) == null) yield return null;
            InitUI();
        }


        private static void InitUI()
        {
            AssetHandler.LoadAssetBundle(BundlePath);
            Icon = AssetHandler.LoadSprite(BundlePath, "BabaIcon");
            InfoIcon = AssetHandler.LoadSprite(BundlePath, "Baba");
            CameraButton = GameObject.Find(CameraPageButton);
            EmojiButton = GameObject.Find(EmojiQmButton);   
            QmToggleButton = GameObject.Find(ToggleButtonPath);
            SelectUserButtonParent = GameObject.Find(UserPagePath);

            var tabButton = new TabButton("ChristmasPageButton", "Christmas Client Menu", "ChristmasPage", Icon,
                CameraButton.transform.parent, CameraButton);
            MainPage = new ChristmasUIPage("ChristmasPage", InfoIcon, "ChristmasGang");
            MenuPages.Add("ChristmasPage", MainPage);

            UserPage = AddPageByName("Christmas User","Targeted User menu" ,SelectUserButtonParent.transform);

            foreach (var uiAction in OnUiInitActions)
                try
                {
                    uiAction?.Invoke();
                }
                catch (Exception e)
                {
                    ConsoleUtils.Error("Error invoking UIInitAction: " + uiAction?.Method.Name + " " +  e );
                }
        }

        #endregion

        #region PageUtils

        /// <summary>
        /// Updates the info panel of every MenuPage with a new status
        /// </summary>
        //could optimize by making it a non static method inside each page and trigger it on page access instead of every page every time the menu is opened
        public static void UpdateStatus()
        {
            foreach (var p in MenuPages)
            {
                var r = Random.RandomRangeInt(0, StatusHandler.Statuses.Length - 1);
                p.Value.ChangePanelInfo(StatusHandler.Statuses[r]);
            }
        }

        /// <summary>
        /// Get ChristmasUIPage from the MenuPages Dictionary.
        /// </summary>
        /// <param name="key"></param>
        /// <returns>Returns the Value or null if it isn't found</returns>
        public static ChristmasUIPage GetPageByName(string key)
        {
            if (MenuPages.ContainsKey(key)) return MenuPages[key];
            ConsoleUtils.Error("Couldn't find page: " + key);
            return null;
        }

        public static ChristmasUIPage AddPageByName(string key, string tooltip = "Christmas", Transform buttonParent = null,
            Action qmButtonAction = null)
        {
            var parent = buttonParent;

            if (!MenuPages.ContainsKey(key))
            {
                if (buttonParent == null) parent = MainPage.ButtonTransform;
                
                QMButton button = new QMButton("Christmas" + key + "Button", tooltip, key, Icon,
                    parent, EmojiButton, () =>
                    {
                        SetPage("Christmas" + key + "Page");
                        qmButtonAction?.Invoke();
                    });


                var page = new ChristmasUIPage("Christmas" + key + "Page", InfoIcon, key, button);
                MenuPages.Add(key, page);
                MenuButtons.Add(key, button);
            }

            return MenuPages[key];
        }

        public static void DestroyPageByName(string key)
        {
            var christmasKey = key;

            var page = GetPageByName(christmasKey);
            if (page != null)
            {
                MenuPages.Remove(christmasKey);
                Object.Destroy(page.ThisPage);
            }
            else
            {
                ConsoleUtils.Error("Failed to remove page: " + christmasKey);
            }
        }


        public static MenuStateController GetMenuState()
        {
            if (MenuState == null)
                MenuState = GameObject.Find("UserInterface/Canvas_QuickMenu(Clone)")
                    .GetComponent<MenuStateController>();

            return MenuState;
        }

        public static void SetPage(string pageName)
        {
            GetMenuState().Method_Public_Void_String_UIContext_Boolean_0(pageName);
        }

        public static void GoBack(UIPage uiPage)
        {
            GetMenuState().Method_Public_Void_UIPage_0(uiPage);
        }
        
        #endregion
    }

    #region Pages

    public class ChristmasUIPage
    {
        public GameObject ThisPage;
        public UIPage ChristmasUiPage;
        public Transform ButtonTransform;
        public QMButton QMButton;
        public string Name;
        public ChristmasUIPage(string name, Sprite infoIcon, string header, QMButton qmButton = null)
        {
            var foundPage = GameObject.Find(ChristmasUI.MenuCameraPagePath);
            ThisPage = Object.Instantiate(foundPage, foundPage.transform.parent, true);
            QMButton = qmButton;
            Name = name;
            ThisPage.name = name;

            Object.Destroy(ThisPage.GetComponent<VRCUiPage>());
            ChristmasUiPage = ThisPage.AddComponent<UIPage>();
            ChristmasUiPage.field_Public_String_0 = name;
            ChristmasUiPage.field_Protected_MenuStateController_0 = ChristmasUI.GetMenuState();
            ChristmasUiPage.field_Private_List_1_UIPage_0.Add(ChristmasUiPage);
            ChristmasUiPage.field_Public_Boolean_0 = true;
            AddToDictionary(name);
            ChangePanelInfo(StatusHandler.Status, infoIcon);
            SetHeader(header);
            RemoveButtons();
            ButtonTransform = ThisPage
                .GetComponentInChildren<GridLayoutGroup>(true).transform;
            
            AddBackButton();

        }

        private int _backButtonCounter =0;
        private void AddBackButton()
        {
            var header = ThisPage.transform.FindChild("Header_Camera/LeftItemContainer");
            if (header == null) return;
            _backButtonCounter++;
            var singleButton = new SingleButton("Christmas" + "back"+ _backButtonCounter + "Button", "Go back", "back", ChristmasUI.Icon,
                header, ChristmasUI.EmojiButton, ()=> ChristmasUI.GoBack(ChristmasUiPage));
            singleButton.ThisButton.transform.FindChild("Background").GetComponent<Transform>().localScale = new Vector3(0.5f, 0.5f, 0.5f);
            var icon = singleButton.ThisButton.transform.FindChild("Icon").GetComponent<Transform>();
            icon.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            icon.localPosition = new Vector3(0f, 0f, 0f);

            singleButton.ThisButton.transform.FindChild("Text_H4").GetComponent<Transform>().localPosition =  new Vector3(0f, 0f, 0f);

            
        }

        
        /// <summary>
        /// Add a button to the parent page
        /// Button Type being SingleButton or ToggleButton
        /// </summary>
        /// <returns>A SingleButton, Toggle Button or empty BaseButton</returns>
        public BaseButton AddButton(ButtonType type, string name, string tooltip = "Christmas", Action onClick = null, Action<bool> onToggle = null, bool defaultState = false)
        {
            switch (type)
            {
                case ButtonType.SingleButton:
                    var button = new SingleButton("Christmas" + name + "Button", tooltip, name, ChristmasUI.Icon,
                        ButtonTransform, ChristmasUI.EmojiButton, onClick);
                    return button;

                case ButtonType.ToggleButton:
                    var toggle = new ToggleButton("Christmas" + name + "Button", tooltip, name, ChristmasUI.Icon,
                        ButtonTransform, ChristmasUI.QmToggleButton, onToggle, defaultState);
                    return toggle;
                default:
                    ConsoleUtils.Error(
                        "Invalid button type enum, please only use Single Button and Toggle Button, got: " + type);
                    var baseButton = new BaseButton();
                    return baseButton;
            }
        }

        public ChristmasUIPage SetHeader(string text)
        {
            var header = ThisPage.transform.FindChild("Header_Camera").gameObject;
            if (header != null)
            {
                var textMesh = header.GetComponentInChildren<TextMeshProUGUI>();
                textMesh.text = text;
            }

            return this;
        }

        public void AddToDictionary(string pageName)
        {
            var menuStateController = ChristmasUI.GetMenuState();
            menuStateController.field_Private_Dictionary_2_String_UIPage_0.Add(pageName, ChristmasUiPage);
            menuStateController.field_Public_ArrayOf_UIPage_0 = menuStateController.field_Public_ArrayOf_UIPage_0
                .Append(ChristmasUiPage).ToArray();
        }

        public ChristmasUIPage RemoveButtons()
        {
            Button[] buttons = ThisPage.GetComponentsInChildren<Button>(true);
            foreach (var b in buttons) Object.Destroy(b.gameObject);

            Toggle[] toggles = ThisPage.GetComponentsInChildren<Toggle>(true);
            foreach (var t in toggles) Object.Destroy(t.gameObject);
            return this;
        }

        public ChristmasUIPage ChangePanelInfo(string text, Sprite sprite = null)
        {
            var panelInfo = ThisPage.transform.FindChild("Panel_Info").gameObject;
            var textMesh = panelInfo.GetComponentInChildren<TextMeshProUGUI>();
            textMesh.text = text;
            if (sprite != null)
            {
                var rawImage = panelInfo.GetComponentInChildren<RawImage>();
                rawImage.m_Texture = sprite.texture;
            }

            return this;
        }
        
        public ChristmasUIPage SetPanelInfoState(bool state)
        {
            var panelInfo = ThisPage.transform.FindChild("Panel_Info").gameObject;
            panelInfo.SetActive(state);
            return this;
        }
    }

    #endregion

    #region Buttons

    public class BaseButton
    {
        public GameObject ThisButton;

        public void SetIcon(Sprite icon)
        {
            var iconTransform = ThisButton.transform.FindChild("Icon");
            if (!iconTransform) iconTransform = ThisButton.transform.FindChild("Icon_On");
            iconTransform.GetComponent<Image>().overrideSprite = icon;
        }

        public void SetTooltip(string text)
        {
            if (ThisButton != null)
                ThisButton.GetComponent<VRC.UI.Elements.Tooltips.UiTooltip>().field_Public_String_0 = text;
        }

        public void SetOnclick(Action onClick)
        {
            ThisButton.GetComponent<Button>().onClick.AddListener(onClick);
        }

        public void SetText(string text)
        {
            var textMesh = ThisButton.GetComponentInChildren<TextMeshProUGUI>();
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
            SetIcon(icon);
            SetTooltip(tooltip);
            SetOnclick(onClick);
            ThisButton.SetActive(true);
            SetText(text);
        }
    }

    public class ToggleButton : BaseButton
    {
        public ToggleButton(string name, string tooltip, string text, Sprite icon, Transform parent,
            GameObject buttonToClone, Action<bool> onToggle = null, bool defaultState = false)
        {
            ThisButton = Object.Instantiate(buttonToClone, parent, true);

            ThisButton.name = name;
            SetIcon(icon);
            SetTooltip(tooltip);
            SetOnToggle(onToggle);
            SetText(text);
            ThisButton.SetActive(true);
            if (defaultState)
            {
                MelonCoroutines.Start(DelayToggleState());
            }
        }
        // TODO find a way to actually display the toggle update when the button isn't shown
        private IEnumerator DelayToggleState()
        {

            yield return new WaitForSeconds(3);
            
            SetToggleState(true);

        }

        public void SetOnToggle(Action<bool> onToggle)
        {
            GetToggle().onValueChanged.AddListener(onToggle);
        }

        public void SetToggleState(bool toggle)
        {
            GetToggle().isOn = toggle;
            GetToggle().Set(toggle);
            
        }

        public Toggle GetToggle()
        {
            return ThisButton.GetComponent<Toggle>();
        }
    }

    public class QMButton : BaseButton
    {
        public QMButton(string name, string tooltip, string text, Sprite icon, Transform parent,
            GameObject buttonToClone, Action onClick = null)
        {
            ThisButton = Object.Instantiate(buttonToClone, parent, true);

            ThisButton.name = name;
            ThisButton.SetActive(true);
            SetIcon(icon);
            SetTooltip(tooltip);
            SetOnclick(onClick);
            SetText(text);
        }
    }

    public class TabButton : BaseButton
    {
        //menu tab
        public MenuTab MTab;

        public TabButton(string name, string tooltip, string pageName, Sprite icon, Transform parent,
            GameObject buttonToClone)

        {
            ThisButton = Object.Instantiate(buttonToClone, parent, true);
            ThisButton.name = name;
            MTab = ThisButton.GetComponent<MenuTab>();
            MTab.field_Public_String_0 = pageName;

            SetIcon(icon);
            SetTooltip(tooltip);
        }
    }

    #endregion
}