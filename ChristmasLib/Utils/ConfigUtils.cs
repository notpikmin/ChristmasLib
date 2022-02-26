using Newtonsoft.Json;
using System;
using System.IO;
using ChristmasLib.Input;
using UnityEngine;

namespace ChristmasLib.Utils
{
    public static class ConfigUtils
    {
        
        public static T Parse<T>(string item)
        {
            return (T)Enum.Parse(typeof(T), item);
        }
        
        public static bool ParseBool(string item)
        {
            return bool.Parse(item);
        }
        
        public static KeyCode ParseKeyCode(string key)
        {
            return (KeyCode)Enum.Parse(typeof(KeyCode), key);
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

            ChristmasKey cKey = new ChristmasKey(keyCode,ctrl);
            return cKey;
        }


        public static T Load<T>(string fileName, T fileObject)
        {
            string path = _configPath + fileName;

            Init(fileName, fileObject);
            T file;
            try
            {
                string fstring = File.ReadAllText(path);
                file = JsonConvert.DeserializeObject<T>(fstring);
            }
            catch
            {
                ConsoleUtils.Error("Failed to load config");
                file = default(T);
            }
            
            return file;
        }

        private static string _configPath = "Christmas/";

        public static void Init(string fileName, System.Object o)
        {
            
            Directory.CreateDirectory(_configPath);
            string path = _configPath + fileName;
            if (!File.Exists(path))
            {
                string config =   JsonConvert.SerializeObject(o, Formatting.Indented);
                File.WriteAllText(path, config);
            }
          
        }

    }
}
