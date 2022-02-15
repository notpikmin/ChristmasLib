using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChristmasLib.Input;
using ChristmasLib.Utils;
using UnityEngine;

namespace ChristmasLib.Utils
{
    public static class ConfigUtils
    {

        public static KeyCode ParseKeyCode(string key)
        {
            return (KeyCode)System.Enum.Parse(typeof(KeyCode), key);
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


        public static T Load<T>(string FileName, T FileObject)
        {
            string path = ConfigPath + FileName;

            Init(FileName, FileObject);
            T file = default(T);
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

        private static string ConfigPath = "Christmas/";

        public static void Init(string FileName, System.Object o)
        {

            Directory.CreateDirectory(ConfigPath);
            string path = ConfigPath + FileName;
            if (!File.Exists(path))
            {
                string config =   JsonConvert.SerializeObject(o, Formatting.Indented);
                File.WriteAllText(path, config);
            }
          
        }

    }
}
