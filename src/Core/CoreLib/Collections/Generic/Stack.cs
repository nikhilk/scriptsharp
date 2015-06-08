// Stack.cs
// Script#/Libraries/CoreLib
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System.Runtime.CompilerServices;

namespace System.Collections.Generic {

    [ScriptImport]
    [ScriptName("Stack")]
    public sealed class Stack<T> {

        [ScriptField]
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
