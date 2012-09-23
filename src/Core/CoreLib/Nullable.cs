// Nullable.cs
// Script#/Libraries/CoreLib
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace System {

    [ScriptIgnoreNamespace]
    [ScriptImport]
    public struct Nullable<T> where T : struct {

        public Nullable(T value) {
        }

        public bool HasValue {
            get {
                return false;
            }
        }

        public T Value {
            get {
                return default(T);
            }
        }

        public T GetValueOrDefault() {
            return default(T);
        }

        public static implicit operator T?(T value) {
            return null;
        }

        public static explicit operator T(T? value) {
            return default(T);
        }
    }
}
