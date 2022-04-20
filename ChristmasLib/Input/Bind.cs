using System;
using UnityEngine;

namespace ChristmasLib.Input
{
    public class Bind
    {

        public KeyCode Key;
        public Action KeyDown,KeyUp,KeyHeld;
        public bool UseCtrl;
        public Bind(KeyCode key, Action keyDown =null,Action keyUp=null,Action keyHeld=null,bool useCtrl = false)
        {
            if (keyDown == null)
            {
                keyDown = () => { };
            }
            if (keyUp == null)
            {
                keyUp = () => { };
            }
            if (keyHeld == null)
            {
                keyHeld = () => { };
            }
            Key = key;
            KeyDown= keyDown;
            KeyUp = keyUp;
            KeyHeld = keyHeld;
            UseCtrl = useCtrl;
        }

    }
}
