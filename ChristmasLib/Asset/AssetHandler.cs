﻿using ChristmasLib.Utils;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace ChristmasLib.Asset
{
    public static class AssetHandler
    {

        public static AssetBundle ChristmasPresent = null;

        public static Texture2D LoadTexture(string path, string assetName)
        {
            if (ChristmasPresent == null) 
            {
                 LoadAssetBundle(path);
            }
            
           
            Texture2D abr = ChristmasPresent.LoadAsset<Texture2D>(assetName);
            UnityEngine.Object.DontDestroyOnLoad(abr);
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
