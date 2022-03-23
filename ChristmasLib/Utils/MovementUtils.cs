using ChristmasLib.Extensions;
using ChristmasLib.Wrappers;
using UnityEngine;
using VRC;
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
            Teleport(p.GetVrcPlayer());
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

        public static void RotateTowards(Transform target, Transform obj, float speed = 2.0f)
        {
            Vector3 targetDirection = target.position - obj.position;

            float singleStep = speed * Time.deltaTime;

            Vector3 newDirection = Vector3.RotateTowards(obj.forward, targetDirection, singleStep, 0.0f);


            obj.rotation = Quaternion.LookRotation(newDirection);
        }

        public static void RotateTowards(GameObject target, GameObject obj, float speed = 2.0f)
        {
            RotateTowards(target.transform, obj.transform, speed);
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
            PlayerWrappers.GetCurrentPlayer().prop_VRCPlayerApi_0.SetJumpImpulse(imp);
        }

        #endregion

    }
}
