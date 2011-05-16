// Tuple.cs
// Script#/Libraries/CoreLib
// Copyright (c) Nikhil Kothari.
// Copyright (c) Microsoft Corporation.
// This source code is subject to terms and conditions of the Microsoft 
// Public License. A copy of the license can be found in License.txt.
//

using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace System {

    [Imported]
    [ScriptNamespace("ss")]
    [ScriptName("Tuple")]
    public sealed class Tuple<T1, T2> {

        public Tuple() {
        }

        public Tuple(T1 first, T2 second) {
        }

        [IntrinsicProperty]
        public T1 First {
            get {
                return default(T1);
            }
            set {
            }
        }

        [IntrinsicProperty]
        public T2 Second {
            get {
                return default(T2);
            }
            set {
            }
        }
    }

    [Imported]
    [ScriptNamespace("ss")]
    [ScriptName("Tuple")]
    public sealed class Tuple<T1, T2, T3> {

        public Tuple() {
        }

        public Tuple(T1 first, T2 second, T3 third) {
        }

        [IntrinsicProperty]
        public T1 First {
            get {
                return default(T1);
            }
            set {
            }
        }

        [IntrinsicProperty]
        public T2 Second {
            get {
                return default(T2);
            }
            set {
            }
        }

        [IntrinsicProperty]
        public T3 Third {
            get {
                return default(T3);
            }
            set {
            }
        }
    }
}
