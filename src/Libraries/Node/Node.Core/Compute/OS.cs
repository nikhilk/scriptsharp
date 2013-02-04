// Process.cs
// Script#/Libraries/Node/Core
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace NodeApi.Compute {

    [ScriptImport]
    [ScriptIgnoreNamespace]
    [ScriptDependency("os")]
    [ScriptName("os")]
    public static class OS {

        [ScriptName("EOL")]
        public static int EndOfLine = 0;

        [ScriptName("arch")]
        public static string GetArchitecture() {
            return null;
        }

        [ScriptName("loadavg")]
        public static int[] GetAverageLoad() {
            return null;
        }

        [ScriptName("cpus")]
        public static object[] GetCPUs() {
            return null;
        }

        [ScriptName("freemem")]
        public static int GetFreeMemory() {
            return 0;
        }

        [ScriptName("hostname")]
        public static string GetHostName() {
            return null;
        }

        [ScriptName("type")]
        public static string GetName() {
            return null;
        }

        [ScriptName("networkInterfaces")]
        public static object[] GetNetworkInterfaces() {
            return null;
        }

        [ScriptName("platform")]
        public static string GetPlatform() {
            return null;
        }

        [ScriptName("release")]
        public static string GetRelease() {
            return null;
        }

        [ScriptName("tmpDir")]
        public static string GetTempDirectory() {
            return null;
        }

        [ScriptName("totalmem")]
        public static int GetTotalMemory() {
            return 0;
        }

        [ScriptName("uptime")]
        public static int GetUptime() {
            return 0;
        }
    }
}
