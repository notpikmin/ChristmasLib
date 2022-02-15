using UnityEngine;

namespace ChristmasLib.Input
{
    public class ChristmasKey
    {
        public KeyCode Key;
        public bool UseCtrl;
        
        public ChristmasKey(KeyCode key, bool useCtrl)
        {
            this.Key = key;
            this.UseCtrl = useCtrl;
        }

        
    }
}