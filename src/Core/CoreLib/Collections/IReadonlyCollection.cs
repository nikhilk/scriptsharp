// IReadonlyCollection.cs
// Script#/Libraries/CoreLib
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System.Runtime.CompilerServices;

namespace System.Collections {

    [ScriptImport]
    [ScriptName("ICollection")]
    public interface IReadonlyCollection : IEnumerable {

        [ScriptField]
        [ScriptName("length")]
        int Count {
            get;
        }

        [ScriptField]
        object this[int index] {
            get;
        }
    }
}
