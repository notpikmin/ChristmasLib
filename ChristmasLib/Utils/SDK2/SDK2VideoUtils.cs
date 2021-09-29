using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using VRCSDK2;

namespace ChristmasLib.Utils.SDK2
{
    public static class SDK2VideoUtils
    {
        public static SyncVideoPlayer[] getSyncVideoPlayers()
        {
            return UnityEngine.Object.FindObjectsOfType<SyncVideoPlayer>();
        }

        public static VRC_SyncVideoPlayer[] getClassicVideoPlayers()
        {
            return UnityEngine.Object.FindObjectsOfType<VRC_SyncVideoPlayer>();
        }
        
        public static IEnumerator addVideo(string url, VRC_SyncVideoPlayer vp)
        {
            vp.Clear();
            vp.AddURL(url);
            yield return new WaitForSeconds(0.5f);
            vp.Next();
        }

        public static IEnumerator addVideo  (string url, SyncVideoPlayer vp)
        {
            addVideo(url, vp.field_Private_VRC_SyncVideoPlayer_0);
            yield return null;
        }



    }
}
