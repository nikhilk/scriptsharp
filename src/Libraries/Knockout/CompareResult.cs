// CompareResult.cs
// Script#/Libraries/Knockout
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace KnockoutApi {

    [ScriptImport]
    [ScriptIgnoreNamespace]
    public class CompareResult<T> {

        [ScriptField]
        public CompareResultStatus Status {
            get;
            set;
        }

        [ScriptField]
        public T Value {
            get;
            set;
        }
    }
}
