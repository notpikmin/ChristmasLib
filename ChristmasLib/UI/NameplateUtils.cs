using UnityEngine;

namespace ChristmasLib.UI
{
    public static class NameplateUtils
    {
        public static PlayerNameplate GetNamePlate(this VRCPlayer p)
        {
            return p.field_Public_PlayerNameplate_0;
        }

        public static GameObject GetInspector(this PlayerNameplate pn)
        {
            return pn.transform.FindChild("Contents/Inspector").gameObject;
        }
        
        public static GameObject CreateNewInspector(VRCPlayer player)
        {
            GameObject inspector = player.GetNamePlate().GetInspector();
            GameObject newObject = Object.Instantiate(inspector,inspector.transform.parent);
            newObject.transform.FindChild("Performance/Container").gameObject.SetActive(false);
            return newObject;
        }
        
        
        
    }
}