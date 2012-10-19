// Stack.cs
// Script#/Libraries/CoreLib
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace System.Collections {

    [ScriptImport]
    public sealed class Stack {

        [ScriptField]
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
