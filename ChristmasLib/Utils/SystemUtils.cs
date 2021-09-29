using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace ChristmasLib.Utils
{
    public static class SystemUtils
    {

        public static string GetClipBoard()
        {
            return GUIUtility.systemCopyBuffer;
        }

        public static void SetClipBoard(string str)
        {
            GUIUtility.systemCopyBuffer = str;
        }


    }
}
