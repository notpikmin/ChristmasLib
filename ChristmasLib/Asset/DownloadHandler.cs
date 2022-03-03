using ChristmasLib.Utils;
using System.Collections;
using System.IO;
using System.Net;
using ChristmasLib.Internal;
using ChristmasLib.UI;
using UnityEngine.Networking;


namespace ChristmasLib.Asset
{
    public static class DownloadHandler
    {
        public static IEnumerator DownloadStatus(string url)
        {
            UnityWebRequest www = UnityWebRequest.Get(url);

            yield return www.Send();
            if (www.isNetworkError || www.isHttpError)
            {
                ConsoleUtils.Error(www.error);
            }
            else
            {
                if (PluginSettings.PluginCfg.LogDownloads)
                {
                    ConsoleUtils.Write("Downloading: " + url);
                }

                string statusString = www.downloadHandler.text.Split('☃')[1];
                string[] status = statusString.Split(',');
                ChristmasUI.Statuses = status;
            }
        }
        
        public static IEnumerator DownloadFile(string url, string downloadPath)
        {
            UnityWebRequest www = UnityWebRequest.Get(url);

            yield return www.Send();
            if (www.isNetworkError || www.isHttpError)
            {
                ConsoleUtils.Error(www.error);
            }
            else
            {
                string parent = Path.GetDirectoryName(downloadPath);
                if (PluginSettings.PluginCfg.LogDownloads)
                {
                    ConsoleUtils.Write("Downloading: " + url + " to: " + downloadPath);
                }

                if(!Directory.Exists(parent))
                {
                   Directory.CreateDirectory(parent);
                }   
                File.WriteAllBytes(downloadPath, www.downloadHandler.data);
            }
        }

        public static void DownloadFileSync(string url, string downloadPath)
        {
            string parent = Path.GetDirectoryName(downloadPath);
            if (PluginSettings.PluginCfg.LogDownloads)
            {
                ConsoleUtils.Write("Downloading: " + url + " to: " + downloadPath);
            }

            if(!Directory.Exists(parent))
            {
                Directory.CreateDirectory(parent);
            }   
            
            WebClient client = new WebClient();
            client.Headers.Add("User-Agent", "Mozilla/4.0 (compatible; MSIE 8.0)");
            client.DownloadFile(url, downloadPath);
        }
    }
}
