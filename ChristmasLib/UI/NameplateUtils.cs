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
        
        public static GameObject CreateNewInspector(VRCPlayer player, string name, string text)
        {
            GameObject inspector = player.GetNamePlate().GetInspector();
            GameObject newObject = Object.Instantiate(inspector,inspector.transform.parent);
            newObject.SetActive(true);

            Object.Destroy(newObject.transform.FindChild("Performance/Container").gameObject);
            newObject.name = name;
            newObject.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = text;
            return newObject;
        }
        
        
    }
}