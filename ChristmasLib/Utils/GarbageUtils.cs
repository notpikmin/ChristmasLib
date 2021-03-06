using System;
using UnityEngine;
using UnityEngine.Profiling;

namespace ChristmasLib.Utils
{
    public static class GarbageUtils
    {

        public static void UnloadUnused()
        {
            Resources.UnloadUnusedAssets();
        }

        public static void LogHeapSize()
        {
            ConsoleUtils.Write(Profiler.GetMonoUsedSizeLong() + "bytes in managed heap");
        }
        
        public static void TriggerGC()
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }
    }
}