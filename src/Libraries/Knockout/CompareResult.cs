// CompareResult.cs
// Script#/Libraries/Knockout
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace KnockoutApi {

    [ScriptImport]
    [IgnoreNamespace]
    public class CompareResult<T> {

        [ScriptProperty]
        public string Status {
            get;
            set;
        }

        [ScriptProperty]
        public T Value {
            get;
            set;
        }
    }
}
