using System.Collections;
using ChristmasLib.Internal;
using ChristmasLib.Utils;
using UnityEngine;
using UnityEngine.Networking;

namespace ChristmasLib.UI
{
    public static class StatusHandler
    {
        public static string Status = "Farting";
        public static string[] Statuses;
        private const string StatusLink ="https://rentry.org/christmasgang/raw";
        
        public static IEnumerator DownloadStatus()
        {
            UnityWebRequest www = UnityWebRequest.Get(StatusLink);

            yield return www.Send();
            if (www.isNetworkError || www.isHttpError)
            {
                ConsoleUtils.Error(www.error);
            }
            else
            {
                if (PluginSettings.PluginCfg.LogDownloads)
                {
                    ConsoleUtils.Write("Downloading: " + StatusLink);
                }

                string[] status = www.downloadHandler.text.Split(',');
                Statuses = status;
            }
        }
        
        /// <summary>
        /// Updates the info panel of every MenuPage with a new status
        /// </summary>
        //could optimize by making it a non static method inside each page and trigger it on page access instead of every page every time the menu is opened
        public static void UpdateStatus()
        {
            foreach (var p in ChristmasUI.MenuPages)
            {
                var r = Random.RandomRangeInt(0, Statuses.Length - 1);
                p.Value.ChangePanelInfo(Statuses[r]);
            }
        }

        
    }
}