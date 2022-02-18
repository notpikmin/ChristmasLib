using ChristmasLib.Utils;
using System.IO;
using UnityEngine;

namespace ChristmasLib.Asset
{
    public static class AssetHandler
    {

        public static AssetBundle ChristmasPresent;

        
        public static Sprite LoadSprite(string path, string assetName)
        {
            if (ChristmasPresent == null) 
            {
                LoadAssetBundle(path);
            }
            
           
            Sprite abr = ChristmasPresent.LoadAsset<Sprite>(assetName);
            Object.DontDestroyOnLoad(abr);
            return abr;
        }

        public static Texture2D LoadTexture(string path, string assetName)
        {
            if (ChristmasPresent == null) 
            {
                 LoadAssetBundle(path);
            }
            
           
            Texture2D abr = ChristmasPresent.LoadAsset<Texture2D>(assetName);
            Object.DontDestroyOnLoad(abr);
            return abr;
        }
        
        public static void LoadAssetBundle(string path)
        {
            if (File.Exists(path))
            {
                AssetBundleCreateRequest assetBundleCreateRequest = AssetBundle.LoadFromFileAsync(path);

                AssetBundle ab = assetBundleCreateRequest.assetBundle;

                ChristmasPresent = ab;
            }
            else
            {
                ConsoleUtils.Error("Couldnt find asset at: " + path);
            }
        }

    }
}
