// Deferred.cs
// Script#/Libraries/CoreLib
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace System.Threading {

    [ScriptImport]
    public abstract class Deferred {

        internal Deferred() {
        }

        [ScriptField]
        public Task Task {
            get {
                return null;
            }
        }

        [ScriptAlias("ss.deferred")]
        public static Deferred Create() {
            return null;
        }

        [ScriptAlias("ss.deferred")]
        public static Deferred<T> Create<T>() {
            return null;
        }

        [ScriptAlias("ss.deferred")]
        public static Deferred<T> Create<T>(T result) {
            return null;
        }

        public void Reject() {
        }

        public void Reject(Exception error) {
        }

        public void Resolve() {
        }
    }

    [ScriptImport]
    [ScriptName("Deferred")]
    public sealed class Deferred<T> : Deferred {

        private Deferred() {
        }

        [ScriptField]
        public new Task<T> Task {
            get {
                return null;
            }
        }

        public void Resolve(T result) {
        }
    }
}
