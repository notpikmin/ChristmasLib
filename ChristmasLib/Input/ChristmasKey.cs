using ChristmasLib.Config;
using UnityEngine;

namespace ChristmasLib.Input
{
    public class ChristmasKey
    {
        public string Key;
        public bool UseCtrl;
        public KeyCode Keycode;
        public ChristmasKey(string key, bool useCtrl)
        {
            Key = key;
            UseCtrl = useCtrl;
            Keycode = ConfigUtils.ParseKeyCode(key);
        }
        
    }
}