// RestifyServerGetOptions.cs
// Script#/Libraries/Node/Restify
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace NodeApi.Restify {

    [ScriptImport]
    [ScriptIgnoreNamespace]
    [ScriptName("Object")]
    public sealed class RestifyServerGetOptions {

        public RestifyServerGetOptions() {
        }

        public RestifyServerGetOptions(params object[] nameValuePairs) {
        }

        public string Path;
        
        public string Version;
    }
}
