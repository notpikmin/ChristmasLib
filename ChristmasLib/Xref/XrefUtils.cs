using System;
using System.Reflection;
using ChristmasLib.Utils;
using UnhollowerRuntimeLib.XrefScans;

namespace ChristmasLib.Xref
{
    public static class XrefUtils
    {
        public static bool XRefScanForMethod(this MethodBase methodBase, string methodName = null, string reflectedType = null)
        {
            foreach (XrefInstance instance in XrefScanner.XrefScan(methodBase))
            {
                var found = false;
                if (instance.Type != XrefType.Method) continue;

                MethodBase resolved = instance.TryResolve();
                if (resolved == null) continue;

                if (!string.IsNullOrEmpty(methodName))
                    found = !string.IsNullOrEmpty(resolved.Name) && resolved.Name.IndexOf(methodName, StringComparison.OrdinalIgnoreCase) >= 0;
                
                if (!string.IsNullOrEmpty(reflectedType))
                    found = !string.IsNullOrEmpty(resolved.ReflectedType?.Name) && resolved.ReflectedType.Name.IndexOf(
                                reflectedType,
                                StringComparison.OrdinalIgnoreCase) >= 0;

                if (found) return true;
            }

            return false;
        }

    }
}