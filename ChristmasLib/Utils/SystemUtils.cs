using System.Diagnostics;
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
        
        public static void OpenExternal(string path)
        {
            Process.Start(path);
        }

    }
}
