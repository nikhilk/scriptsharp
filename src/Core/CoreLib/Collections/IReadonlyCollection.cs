// IReadonlyCollection.cs
// Script#/Libraries/CoreLib
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System.Runtime.CompilerServices;

namespace System.Collections {

    [Imported]
    [ScriptNamespace("ss")]
    [ScriptName("ICollection")]
    public interface IReadonlyCollection : IEnumerable {

        [IntrinsicProperty]
        [ScriptName("length")]
        int Count {
            get;
        }

        [IntrinsicProperty]
        object this[int index] {
            get;
        }
    }
}
