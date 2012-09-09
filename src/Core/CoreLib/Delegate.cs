// Delegate.cs
// Script#/Libraries/CoreLib
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System.Runtime.CompilerServices;

namespace System {

    [Imported]
    public abstract class Delegate {

        public static readonly Delegate Empty = null;

        protected Delegate(object target, string method) {
        }

        protected Delegate(Type target, string method) {
        }

        public static void ClearExport(string name) {
        }

        public static Delegate Combine(Delegate a, Delegate b) {
            return null;
        }

        public static Delegate Create(object instance, Function f) {
            return null;
        }

        public static string CreateExport(Delegate d) {
            return null;
        }

        public static string CreateExport(Delegate d, bool multiUse) {
            return null;
        }

        public static string CreateExport(Delegate d, bool multiUse, string name) {
            return null;
        }

        public static void DeleteExport(string name) {
        }

        public static Delegate Remove(Delegate source, Delegate value) {
            return null;
        }
    }
}
