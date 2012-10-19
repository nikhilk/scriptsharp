// Tuple.cs
// Script#/Libraries/CoreLib
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace System {

    [ScriptImport]
    [ScriptIgnoreNamespace]
    [ScriptName("Tuple")]
    public sealed class Tuple<T1, T2> {

        public Tuple() {
        }

        public Tuple(T1 item1, T2 item2) {
        }

        [ScriptField]
        public T1 Item1 {
            get {
                return default(T1);
            }
            set {
            }
        }

        [ScriptField]
        public T2 Item2 {
            get {
                return default(T2);
            }
            set {
            }
        }
    }

    [ScriptImport]
    [ScriptIgnoreNamespace]
    [ScriptName("Tuple")]
    public sealed class Tuple<T1, T2, T3> {

        public Tuple() {
        }

        public Tuple(T1 item1, T2 item2, T3 item3) {
        }

        [ScriptField]
        public T1 Item1 {
            get {
                return default(T1);
            }
            set {
            }
        }

        [ScriptField]
        public T2 Item2 {
            get {
                return default(T2);
            }
            set {
            }
        }

        [ScriptField]
        public T3 Item3 {
            get {
                return default(T3);
            }
            set {
            }
        }
    }

    [ScriptImport]
    [ScriptIgnoreNamespace]
    [ScriptName("Tuple")]
    public sealed class Tuple<T1, T2, T3, T4> {

        public Tuple() {
        }

        public Tuple(T1 item1, T2 item2, T3 item3, T4 item4) {
        }

        [ScriptField]
        public T1 Item1 {
            get {
                return default(T1);
            }
            set {
            }
        }

        [ScriptField]
        public T2 Item2 {
            get {
                return default(T2);
            }
            set {
            }
        }

        [ScriptField]
        public T3 Item3 {
            get {
                return default(T3);
            }
            set {
            }
        }

        [ScriptField]
        public T4 Item4 {
            get {
                return default(T4);
            }
            set {
            }
        }
    }
}
