using ChristmasLib.Config;
using UnityEngine;

namespace ChristmasLib.Input
{
    public class ChristmasKey
    {
        public string Key;
        public bool UseCtrl;
        //public KeyCode Keycode;
        public ChristmasKey(KeyCode key, bool useCtrl)
        {
            Key = key.ToString();
            UseCtrl = useCtrl;
        }

        public ChristmasKey(string key, bool useCtrl)
        {
            Key = key;
            UseCtrl = useCtrl;
        }
     

        public KeyCode GetKeyCode()
        {
            return ConfigUtils.ParseKeyCode(Key);
        }
    }
}