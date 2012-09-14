// Delegate.cs
// Script#/Libraries/CoreLib
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System.Runtime.CompilerServices;

namespace System {

    [Imported]
    public abstract class Delegate {

        [PreserveCase]
        public static readonly Delegate Empty = null;

        protected Delegate(object target, string method) {
        }

        protected Delegate(Type target, string method) {
        }

        public static Delegate Combine(Delegate a, Delegate b) {
            return null;
        }

        public static Delegate Create(object instance, Function f) {
            return null;
        }

        [ScriptName("publish")]
        public static Export Export(Delegate d) {
            return null;
        }

        [ScriptName("publish")]
        public static Export Export(Delegate d, bool multiUse) {
            return null;
        }

        [ScriptName("publish")]
        public static Export Export(Delegate d, bool multiUse, string name) {
            return null;
        }

        [ScriptName("publish")]
        public static Export Export(Delegate d, bool multiUse, string name, object root) {
            return null;
        }

        public static Delegate Remove(Delegate source, Delegate value) {
            return null;
        }
    }
}
