// Stack.cs
// Script#/Libraries/CoreLib
// Copyright (c) Nikhil Kothari.
// Copyright (c) Microsoft Corporation.
// This source code is subject to terms and conditions of the Microsoft 
// Public License. A copy of the license can be found in License.txt.
//

using System.Runtime.CompilerServices;

namespace System.Collections.Generic {

    /// <summary>
    /// The Stack data type which is mapped to the Array type in Javascript.
    /// </summary>
    [IgnoreNamespace]
    [Imported]
    [ScriptName("Array")]
    public sealed class Stack<T> {

        [IntrinsicProperty]
        [ScriptName("length")]
        public int Count {
            get {
                return 0;
            }
        }

        public void Clear() {
        }

        public bool Contains(T item) {
            return false;
        }

        public T Peek() {
            return default(T);
        }

        public T Pop() {
            return default(T);
        }

        public void Push(T item) {
        }
    }
}
