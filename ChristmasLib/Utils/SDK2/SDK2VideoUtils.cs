using System.Collections;
using UnityEngine;
using VRCSDK2;

namespace ChristmasLib.Utils.SDK2
{
    public static class SDK2VideoUtils
    {
        public static SyncVideoPlayer[] GetSyncVideoPlayers()
        {
            return Object.FindObjectsOfType<SyncVideoPlayer>();
        }

        public static VRC_SyncVideoPlayer[] GetClassicVideoPlayers()
        {
            return Object.FindObjectsOfType<VRC_SyncVideoPlayer>();
        }
        
        public static IEnumerator AddVideo(string url, VRC_SyncVideoPlayer vp)
        {
            vp.Clear();
            vp.AddURL(url);
            yield return new WaitForSeconds(0.5f);
            vp.Next();
        }

        public static IEnumerator AddVideo (string url, SyncVideoPlayer vp)
        {
            yield return AddVideo(url, vp.field_Private_VRC_SyncVideoPlayer_0);
            
        }



    }
}
