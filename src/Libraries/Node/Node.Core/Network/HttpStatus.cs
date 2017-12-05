// HttpStatus.cs
// Script#/Libraries/Node/Core
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace NodeApi.Network {

    [ScriptImport]
    [ScriptIgnoreNamespace]
    public sealed class HttpStatus {

        private HttpStatus() {
        }

        public string this[int statusCode] {
            get {
                return null;
            }
        }
    }
}
