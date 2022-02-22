using System;

namespace ChristmasLib.Utils
{
    public static class GarbageUtils
    {
        public static void TriggerGC()
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }
    }
}