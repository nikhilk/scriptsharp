// ICollection.cs
// Script#/Libraries/CoreLib
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System.Runtime.CompilerServices;

namespace System.Collections {

    [ScriptImport]
    [ScriptName("ICollection")]
    public interface ICollection : IEnumerable {

        [ScriptProperty]
        [ScriptName("length")]
        int Count {
            get;
        }

        [ScriptProperty]
        object this[int index] {
            get;
            set;
        }
    }
}
