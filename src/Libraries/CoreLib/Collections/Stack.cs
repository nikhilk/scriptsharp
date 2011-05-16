// Stack.cs
// Script#/Libraries/CoreLib
// Copyright (c) Nikhil Kothari.
// Copyright (c) Microsoft Corporation.
// This source code is subject to terms and conditions of the Microsoft 
// Public License. A copy of the license can be found in License.txt.
//

using System;
using System.Runtime.CompilerServices;

namespace System.Collections {

    /// <summary>
    /// The Stack data type which is mapped to the Array type in Javascript.
    /// </summary>
    [IgnoreNamespace]
    [Imported]
    [ScriptName("Array")]
    public sealed class Stack {

        [IntrinsicProperty]
        [ScriptName("length")]
        public int Count {
            get {
                return 0;
            }
        }

        public void Clear() {
        }

        public bool Contains(object item) {
            return false;
        }

        public object Peek() {
            return null;
        }

        public object Pop() {
            return null;
        }

        public void Push(object item) {
        }
    }
}
