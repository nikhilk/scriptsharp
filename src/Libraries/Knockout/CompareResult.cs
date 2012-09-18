// CompareResult.cs
// Script#/Libraries/Knockout
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace KnockoutApi {

    [Imported]
    [IgnoreNamespace]
    public class CompareResult<T> {

        [IntrinsicProperty]
        public CompareResultStatus Status
        {
            get;
            set;
        }

        [IntrinsicProperty]
        public T Value {
            get;
            set;
        }
    }

    [NamedValues]
    public enum CompareResultStatus{
        added,
        deleted,
        retained
    }
}
