// Node.cs
// Script#/Libraries/Node/Core
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;
using NodeApi.Compute;

namespace NodeApi {

    /// <summary>
    /// The global Node object.
    /// </summary>
    [ScriptImport]
    [ScriptIgnoreNamespace]
    public static class Node {

        [ScriptProperty]
        [ScriptAlias("process")]
        public static Process Process {
            get {
                return null;
            }
        }
    }
}
