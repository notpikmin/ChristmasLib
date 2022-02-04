﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace ChristmasLib.Input
{
    public class Bind
    {

        public KeyCode Key;
        public Action KeyDown,KeyUp,KeyHeld;

        public Bind(KeyCode key, Action keyDown =null,Action keyUp=null,Action keyHeld=null)
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
            this.Key = key;
            this.KeyDown= keyDown;
            this.KeyUp = keyUp;
            this.KeyHeld = keyHeld;
        }

    }
}
