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

        [ScriptProperty]
        [ScriptName("$data")]
        public T Data {
            get;
            set;
        }

        [ScriptProperty]
        [ScriptName("$parent")]
        public TParent Parent {
            get;
            set;
        }

        [ScriptProperty]
        [ScriptName("$parents")]
        public TParent[] Parents {
            get;
            set;
        }

        [ScriptProperty]
        [ScriptName("$root")]
        public TRoot[] Root {
            get;
            set;
        }
    }
}
