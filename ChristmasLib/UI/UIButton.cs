using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
namespace ChristmasLib.UI
{
    public class UIButton
    {


        public string Text;
        public float Width, Height,x,y;
        public UnityAction OnClick;
        public Color BGColor,TextColor;
        public GameObject gameObject;

        UIButton(string text, float width, float height, UnityAction onClick, Color bgColor, Color textcolor, float xp = 0,float yp =0)
        {
            this.Text = text;
            this.Width = width;
            this.Height = height;
            this.OnClick = onClick;
            this.x = xp;
            this.y = yp;
            this.BGColor = bgColor;
            this.TextColor = textcolor;

        }

        public static GameObject createButton(UIButton btn)
        {
            GameObject ButtonObject = new GameObject();
            ButtonObject.name = "Button" + btn.Text;

            RectTransform btnran = ButtonObject.AddComponent<RectTransform>();

            Button Button = ButtonObject.AddComponent<Button>();
            Button.onClick.AddListener(btn.OnClick);

            Image BtnBG = ButtonObject.AddComponent<Image>();
            BtnBG.sprite = null;
            BtnBG.color = btn.BGColor;

            GameObject TextObject = new GameObject();
            TextObject.name = "Text";
            TextObject.transform.parent = ButtonObject.transform;

            Text BtnText = TextObject.AddComponent<Text>();
            BtnText.resizeTextForBestFit = true;
            BtnText.alignment = TextAnchor.MiddleCenter;
            BtnText.text = btn.Text;
            BtnText.color = btn.TextColor;

            return ButtonObject;
        }
        

    }
}
