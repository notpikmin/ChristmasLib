using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChristmasLib.Input
{
   public class InputManager:ChristmasMod
    {
        public static List<Bind> Binds = new List<Bind>();
        public override void OnUpdate()
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
