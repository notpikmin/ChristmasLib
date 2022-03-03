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

        public static List<ChristmasConfig> Configs;

        public static void UpdateConfigs()
        {
            foreach (ChristmasConfig cfg in Configs)
            {
                //cfg.Load(cfg.ObjectType);
                cfg.OnUpdate();
            }
        } 
        
        private static string _configPath = "Christmas/";

        public static void FileSystemWatcher()
        {
             var watcher = new FileSystemWatcher(_configPath);
             watcher.NotifyFilter = NotifyFilters.Attributes
                                    | NotifyFilters.CreationTime
                                    | NotifyFilters.DirectoryName
                                    | NotifyFilters.FileName
                                    | NotifyFilters.LastAccess
                                    | NotifyFilters.LastWrite
                                    | NotifyFilters.Security
                                    | NotifyFilters.Size;

             watcher.Changed += OnChanged;
             watcher.Error += OnError;

             watcher.Filter = "*.json";
             watcher.IncludeSubdirectories = false;
             watcher.EnableRaisingEvents = true;

        }
        
        private static void OnChanged(object sender, FileSystemEventArgs e)
        {
            if (e.ChangeType != WatcherChangeTypes.Changed)
            {
                return;
            }
            ConsoleUtils.Debug($"Changed: {e.FullPath}");
            UpdateConfigs();
        }

        private static void OnError(object sender, ErrorEventArgs e)
        {
            ConsoleUtils.Error(e.GetException().Message);
        }
        
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

            ChristmasKey cKey = new ChristmasKey(keyCode, ctrl);
            return cKey;
        }

    }
}
