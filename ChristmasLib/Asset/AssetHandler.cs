using ChristmasLib.Utils;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace ChristmasLib.Asset
{
    public static class AssetHandler
    {

        public static Dictionary<string, AssetBundle> AssetBundles = new Dictionary<string, AssetBundle>();

        public static UnityEngine.Object LoadAsset<T>(string path, string assetName)
        {
            AssetBundle ab;
            if (!AssetBundles.TryGetValue(path,out ab))
            {
                 LoadAssetBundle(path);
            }
            AssetBundles.TryGetValue(path, out ab);
            AssetBundleRequest abr = ab.LoadAssetAsync<T>(assetName);
            
            return abr.asset;
        }
        
        public static void LoadAssetBundle(string path)
        {
            if (File.Exists(path))
            {
                AssetBundleCreateRequest assetBundleCreateRequest = AssetBundle.LoadFromFileAsync(path);

                AssetBundle ab = assetBundleCreateRequest.assetBundle;

                AssetBundles.Add(path, ab);
               
            }
            else
            {
                ConsoleUtils.Error("Couldnt find asset at: " + path);
            }
        }

    }
}
