// Nullable.cs
// Script#/Libraries/CoreLib
// Copyright (c) Nikhil Kothari.
// Copyright (c) Microsoft Corporation.
// This source code is subject to terms and conditions of the Microsoft 
// Public License. A copy of the license can be found in License.txt.
//

using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace System {

    [IgnoreNamespace]
    [Imported]
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

        public static implicit operator T?(T value) {
            return null;
        }

        public static explicit operator T(T? value) {
            return default(T);
        }
    }
}
