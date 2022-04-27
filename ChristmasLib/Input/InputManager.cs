using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace ChristmasLib.Input
{
    public class InputManager
    {
        public List<Bind> Binds = new List<Bind>();
        public void Check()
        {
            if (Binds == null) { return; }

            //foreach bind where useCtrl is false or left control is down
            //only executes if use ctrl is off or left control is down
            foreach (var b in Binds.Where(b => !b.UseCtrl || UnityEngine.Input.GetKey(KeyCode.LeftControl)))
            {
                if (UnityEngine.Input.GetKeyDown(b.Key))
                {
                    b.KeyDown();
                }

                if (UnityEngine.Input.GetKeyUp(b.Key))
                {
                    b.KeyUp();
                }

                if (UnityEngine.Input.GetKey(b.Key))
                {
                    b.KeyHeld();
                }
            }C
        }
    }
}