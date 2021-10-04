using ChristmasLib.Extensions;
using ChristmasLib.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using VRC;
using VRC.SDKBase;
using ChristmasLib.Utils;
namespace ChristmasLib.Utils
{
    public static class MovementUtils
    {
        #region Teleport
        public static void Teleport(Vector3 pos)
        {
            VRCPlayer p = PlayerWrappers.GetCurrentPlayer();
            if (p != null)
            {
                p.transform.position = pos;
            }
        }
        public static void Teleport(VRCPlayer p)
        {
            Teleport(p.transform.position);
        }

        public static void Teleport(Player p)
        {
            Teleport(p.GetVRCPlayer());
        }

        public static void Teleport(string name)
        {
            Teleport(PlayerWrappers.GetPlayerManager().GetPlayerByName(name));
        }
        #endregion

        #region Rotate
        public static void Rotate(Quaternion r)
        {
            VRCPlayer p = PlayerWrappers.GetCurrentPlayer();
            p.transform.rotation = r;
        }

        public static void RotateTowards(Transform Target, Transform obj)
        {
            Vector3 targetDirection = Target.position - obj.position;

            float singleStep = 2.0f * Time.deltaTime;

            Vector3 newDirection = Vector3.RotateTowards(obj.forward, targetDirection, singleStep, 0.0f);


            obj.rotation = Quaternion.LookRotation(newDirection);
        }

        public static void RotateTowards(GameObject Target, GameObject obj)
        {
            RotateTowards(Target.transform, obj.transform);
        }

        #endregion

        #region Physics

        public static void ResetGravity()
        {
            Physics.gravity = WorldUtils.GetSceneDescriptor().gravity;
        }


        public static void SetGravity(float grav)
        {
            Physics.gravity = new Vector3(0,grav,0);
        }

        public static void SetGravity(Vector3 grav)
        {
            Physics.gravity = grav;
        }


        #endregion

        #region PlayerMods

        public static void SetJump(float imp = 2.2f)
        {
            Wrappers.PlayerWrappers.GetCurrentPlayer().prop_VRCPlayerApi_0.SetJumpImpulse(imp);
        }

        #endregion

    }
}
