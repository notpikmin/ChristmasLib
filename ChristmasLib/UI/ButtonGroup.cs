using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace ChristmasLib.UI
{
    public class ButtonGroup
    {

        public List<UIButton> Buttons;
        public float panelHeight, x,y,ButtonGap,ButtonBorder;
        public string Name;
        public Color BGColor;
        public GameObject gameobj;
        public ButtonGroup(string name, List<UIButton> buttons, float bWidth,float bHeight, float buttonGap,float buttonBorder,Color BGColor, float xp = 0, float yp = 0)
        {
            this.Buttons = buttons;
            this.panelHeight = (bHeight * buttons.Count) + (buttonGap * buttons.Count);
            this.x = xp;
            this.y = yp;
            this.ButtonGap = buttonGap;
            this.ButtonBorder = buttonBorder;
            this.Name = name;
            this.gameobj = initButtonGroup(this);

        }

        private GameObject initButtonGroup(ButtonGroup b)
        {
            GameObject BtnGrpObj = new GameObject();
            BtnGrpObj.name = b.Name;
            RectTransform rect= BtnGrpObj.AddComponent<RectTransform>();
            rect.sizeDelta = new Vector2( b.panelHeight + b.ButtonBorder,b.panelHeight);
            rect.anchoredPosition = new Vector2(b.x, b.y);
            rect.anchorMin = new Vector2(0.5f, 1);
            rect.anchorMax = new Vector2(0.5f, 1);
            rect.pivot = new Vector2(0.5f, 0.5f);

            Image panel = BtnGrpObj.AddComponent<Image>();
            panel.sprite = null;
            panel.color = b.BGColor;


            foreach (UIButton uiB in b.Buttons)
            {
                GameObject btn = UIButton.createButton(uiB);
                btn.transform.parent = BtnGrpObj.transform;
                RectTransform btnt = btn.AddComponent<RectTransform>();
                btnt.anchoredPosition = new Vector2(uiB.x, uiB.y);

            }

            return BtnGrpObj;
        }


    }
}
