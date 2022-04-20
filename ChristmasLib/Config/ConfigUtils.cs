using System;
using System.Collections.Generic;
using System.IO;
using ChristmasLib.Input;
using ChristmasLib.Utils;
using UnityEngine;

namespace ChristmasLib.Config
{
    public static class ConfigUtils
    {

        public static List<ChristmasConfig> Configs = new List<ChristmasConfig>();
        public const string ConfigPath = "Christmas/";

        #region Updating
        public static void UpdateConfigs()
        {
            foreach (ChristmasConfig cfg in Configs)
            {
                //cfg.Load(cfg.ObjectType);
                cfg.OnUpdate();
            }
        } 
        #endregion

        #region FileWatcher
        public static void FileSystemWatcher()
        {
             var watcher = new FileSystemWatcher(ConfigPath);
             watcher.NotifyFilter = NotifyFilters.DirectoryName | NotifyFilters.FileName | NotifyFilters.LastWrite | NotifyFilters.Size;
             watcher.Changed += (sender, e) =>
             {
                   if (e.ChangeType != WatcherChangeTypes.Changed) { return;}
                   ConsoleUtils.Debug($"Changed: {e.FullPath}");
                   UpdateConfigs();
             };
             watcher.Error += (sender, e) =>
             {
                 ConsoleUtils.Error(e.GetException().Message);

             };
             watcher.Filter = "*.json";
             watcher.IncludeSubdirectories = false;
             watcher.EnableRaisingEvents = true;

        }
        #endregion
        
        #region Parsing
        public static T Parse<T>(string item)
        {
            return (T) Enum.Parse(typeof(T), item);
        }

        public static bool ParseBool(string item)
        {
            return bool.Parse(item);
        }

        public static KeyCode ParseKeyCode(string key)
        {
            return (KeyCode) Enum.Parse(typeof(KeyCode), key);
        }
        
        public static ChristmasKey ParseKey(string input)
        {
            string[] inputs = input.Split('|');

            KeyCode keyCode = ParseKeyCode(inputs[0]);
            bool ctrl = false;
            if (inputs.Length >= 2)
            {
                ctrl = inputs[1].ToLower().Contains("ctrl");
            }

            ChristmasKey cKey = new ChristmasKey(keyCode.ToString(), ctrl);
            return cKey;
        }
        #endregion
    }
}
