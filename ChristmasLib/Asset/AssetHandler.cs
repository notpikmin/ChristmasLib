using ChristmasLib.Utils;
using System.IO;
using Il2CppSystem.Collections.Generic;
using UnityEngine;

namespace ChristmasLib.Asset
{
    public static class AssetHandler
    {

        public static List<AssetBundle> ChristmasPresent = new List<AssetBundle>();

        

        public static T LoadAnything<T>(string path, string assetName) where T : Object
        {
            if (ChristmasPresent == null) 
            {
                LoadAssetBundle(path);
            }

            foreach (var a in ChristmasPresent)
            {
                T abr = a.LoadAsset<T>(assetName);
                if (abr != null)
                {
                    Object.DontDestroyOnLoad(abr);
                    return abr;
                }
            }
            return null;
        }

        #region Texture
        public static Sprite LoadSprite(string path, string assetName)
        {
           if (ChristmasPresent == null) 
           {
               LoadAssetBundle(path);
           }
           foreach (var a in ChristmasPresent)
           {
               Sprite abr = a.LoadAsset<Sprite>(assetName);
               if (abr != null)
               {
                   Object.DontDestroyOnLoad(abr);
                   return abr;
               }
           }
           return null;
        }

        public static Texture2D LoadTexture(string path, string assetName)
        {
            if (ChristmasPresent == null) 
            {
                LoadAssetBundle(path);
            }
            foreach (var a in ChristmasPresent)
            {
                Texture2D abr = a.LoadAsset<Texture2D>(assetName);
                if (abr != null)
                {
                    Object.DontDestroyOnLoad(abr);
                    return abr;
                }
            }
            return null;
        }
        #endregion
        
        #region AssetBundle
        public static void LoadAssetBundle(string path)
        {
            if (File.Exists(path))
            {
                AssetBundleCreateRequest assetBundleCreateRequest = AssetBundle.LoadFromFileAsync(path);

                AssetBundle ab = assetBundleCreateRequest.assetBundle;

                ChristmasPresent.Add(ab);
            }
            else
            {
                ConsoleUtils.Error("Couldn't find asset at: " + path);
            }
        }
        #endregion
    }
}
