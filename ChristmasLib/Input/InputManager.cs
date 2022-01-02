using ChristmasLib.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChristmasLib.Input
{
   public class InputManager
    {
        public  List<Bind> Binds = new List<Bind>();
        public  void Check()
        {
            if (Binds != null)
            {
                foreach(Bind b in Binds)
                {
                    if (UnityEngine.Input.GetKeyDown(b.Key)) { b.KeyDown(); }
                    if (UnityEngine.Input.GetKeyUp(b.Key)) { b.KeyUp(); }
                    if (UnityEngine.Input.GetKey(b.Key)) { b.KeyHeld(); }

                }
            }
        }

    }
}
