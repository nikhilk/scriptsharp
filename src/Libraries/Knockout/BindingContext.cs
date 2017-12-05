// BindingContext.cs
// Script#/Libraries/Knockout
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace KnockoutApi {

    [ScriptImport]
    [ScriptIgnoreNamespace]
    public class BindingContext<TRoot, TParent, T> {

        [ScriptField]
        [ScriptName("$data")]
        public T Data {
            get;
            set;
        }

        [ScriptField]
        [ScriptName("$parent")]
        public TParent Parent {
            get;
            set;
        }

        [ScriptField]
        [ScriptName("$parents")]
        public TParent[] Parents {
            get;
            set;
        }

        [ScriptField]
        [ScriptName("$root")]
        public TRoot[] Root {
            get;
            set;
        }
    }
}
