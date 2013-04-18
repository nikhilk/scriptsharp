// CloudBlob.cs
// Script#/Libraries/Node/Azure
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace NodeApi.WindowsAzure.Storage {

    [ScriptImport]
    [ScriptIgnoreNamespace]
    public abstract class CloudBlob {

        internal CloudBlob() {
        }

        [ScriptField]
        [ScriptName("blob")]
        public string Name {
            get {
                return null;
            }
        }
    }
}
