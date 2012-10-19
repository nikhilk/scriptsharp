// Queue.cs
// Script#/Libraries/CoreLib
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace System.Collections {

    [ScriptImport]
    public sealed class Queue {

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

        public object Dequeue() {
            return null;
        }

        public void Enqueue(object item) {
        }

        public object Peek() {
            return null;
        }
    }
}
