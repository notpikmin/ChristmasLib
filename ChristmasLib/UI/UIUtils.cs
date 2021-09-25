using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace ChristmasLib.UI
{
    public static class UIUtils
    {
        public static GameObject CanvasObject;
        public static void UIStart(string id)
        {
            CanvasObject = new GameObject();
            CanvasObject.name = id;   
            UnityEngine.Object.DontDestroyOnLoad(CanvasObject);

            Canvas canvas = CanvasObject.AddComponent<Canvas>();
            canvas.renderMode = RenderMode.ScreenSpaceOverlay;




        }



    }
}
