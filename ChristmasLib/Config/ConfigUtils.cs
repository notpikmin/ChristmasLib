using System;
using System.Collections.Generic;
using ChristmasLib.Input;
using UnityEngine;

namespace ChristmasLib.Config
{
    public static class ConfigUtils
    {

        public static List<ChristmasConfig> Configs;

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
