using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChristmasLib.Utils
{
    public static class WorldUtils
    {
        public static ObjectInstantiator GetObjectInstantiator()
        {
            return UnityEngine.Object.FindObjectOfType<ObjectInstantiator>();
        }

        public static List<string> GetInstantiableObjects()
        {
            ObjectInstantiator objI = GetObjectInstantiator();
            List<string> objs = new List<string>();
            foreach(string s in objI.field_Private_Dictionary_2_String_ObjectNPrivateStGaSiUnique_0.Keys)
            {
                objs.Add(s);
            }
            return objs;

        }

    }
}
