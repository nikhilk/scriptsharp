// IReadonlyCollection.cs
// Script#/Libraries/CoreLib
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System.Runtime.CompilerServices;

namespace System.Collections.Generic {

    [ScriptImport]
    [ScriptName("ICollection")]
    public interface IReadonlyCollection<T> : IEnumerable<T> {

        [ScriptProperty]
        [ScriptName("length")]
        int Count {
            get;
        }

        [ScriptProperty]
        T this[int index] {
            get;
        }
    }
}
