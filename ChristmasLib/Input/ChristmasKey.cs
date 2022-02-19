using UnityEngine;

namespace ChristmasLib.Input
{
    public class ChristmasKey
    {
        public KeyCode Key;
        public bool UseCtrl;
        
        public ChristmasKey(KeyCode key, bool useCtrl)
        {
            Key = key;
            UseCtrl = useCtrl;
        }

        
    }
}