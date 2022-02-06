using ChristmasLib.Utils;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.Networking;

namespace ChristmasLib.Asset
{
    public static class DownloadHandler
    {

        public static IEnumerator Download(string url, string downloadPath)
        {
            UnityWebRequest www = UnityWebRequest.Get(url);

            yield return www.Send();
            if (www.isNetworkError || www.isHttpError)
            {
                ConsoleUtils.Error(www.error);
            }
            else
            {
                System.IO.File.WriteAllBytes(downloadPath, www.downloadHandler.data);
            }
        }


    }
}
