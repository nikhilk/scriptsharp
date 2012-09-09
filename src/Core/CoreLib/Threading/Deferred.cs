// Deferred.cs
// Script#/Libraries/CoreLib
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace System.Threading {

    [Imported]
    public class Deferred {

        [IntrinsicProperty]
        public Task Task {
            get {
                return null;
            }
        }

        public void Reject() {
        }

        public void Reject(Exception error) {
        }

        public void Resolve() {
        }
    }

    [Imported]
    [ScriptName("Deferred")]
    public sealed class Deferred<T> : Deferred {

        [IntrinsicProperty]
        public new Task<T> Task {
            get {
                return null;
            }
        }

        public void Resolve(T result) {
        }
    }
}
