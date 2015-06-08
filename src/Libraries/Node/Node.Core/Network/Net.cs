// Socket.cs
// Script#/Libraries/Node/Core
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace NodeApi.Network {

    [ScriptImport]
    [ScriptIgnoreNamespace]
    [ScriptDependency("net")]
    public static class Net {

        [ScriptName("isIP")]
        public static IPAddressType IsIP(string input) {
            return 0;
        }

        [ScriptName("isIPv4")]
        public static bool IsIPv4(string input) {
            return false;
        }

        [ScriptName("isIPv6")]
        public static bool IsIPv6(string input) {
            return false;
        }
    }
}
