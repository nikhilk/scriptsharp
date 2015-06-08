// ExpressRoute.cs
// Script#/Libraries/Node/Express
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace NodeApi.ExpressJS {

    [ScriptImport]
    [ScriptIgnoreNamespace]
    [ScriptName("Object")]
    public sealed class ExpressRoute {

        private ExpressRoute() {
        }

        [ScriptField]
        public object[] Callbacks {
            get {
                return null;
            }
        }

        [ScriptField]
        public object[] Keys {
            get {
                return null;
            }
        }

        [ScriptField]
        public string Method {
            get {
                return null;
            }
        }

        [ScriptField]
        public string Path {
            get {
                return null;
            }
        }

        [ScriptField]
        public RegExp RegExp {
            get {
                return null;
            }
        }
    }
}
