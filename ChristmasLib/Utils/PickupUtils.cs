using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using VRC.SDKBase;

namespace ChristmasLib.Utils
{
   public static class PickupUtils
    {
        public static List<VRC_Pickup> getAllPickups()
        {
            return Resources.FindObjectsOfTypeAll<VRC_Pickup>().ToList();
        }

        public static List<Rigidbody> getAllPickupsRigidBodies()
        {
            List<VRC_Pickup> pickups = getAllPickups();
            List<Rigidbody> rigid = new List<Rigidbody>();
            foreach(VRC_Pickup p in pickups)
            {
                rigid.Add(p.GetComponent<Rigidbody>());
            }
            return rigid;
        }



    }
}
