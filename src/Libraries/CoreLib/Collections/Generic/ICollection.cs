// ICollection.cs
// Script#/Libraries/CoreLib
// Copyright (c) Nikhil Kothari.
// Copyright (c) Microsoft Corporation.
// This source code is subject to terms and conditions of the Microsoft 
// Public License. A copy of the license can be found in License.txt.
//

using System.Runtime.CompilerServices;

namespace System.Collections.Generic {

    [Imported]
    [ScriptNamespace("ss")]
    [ScriptName("ICollection")]
    public interface ICollection<T> : IEnumerable<T> {

        [IntrinsicProperty]
        [ScriptName("length")]
        int Count {
            get;
        }

        [IntrinsicProperty]
        T this[int index] {
            get;
            set;
        }
    }
}
