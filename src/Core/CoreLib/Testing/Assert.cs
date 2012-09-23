// Assert.cs
// Script#/Libraries/CoreLib
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace System.Testing {

    [ScriptIgnoreNamespace]
    [ScriptImport]
    public static class Assert {

        [ScriptAlias("QUnit.equal")]
        public static void AreEqual(object actual, object expected) {
        }

        [ScriptAlias("QUnit.equal")]
        public static void AreEqual(object actual, object expected, string message) {
        }

        [ScriptAlias("QUnit.notEqual")]
        public static void AreNotEqual(object actual, object expected) {
        }

        [ScriptAlias("QUnit.notEqual")]
        public static void AreNotEqual(object actual, object expected, string message) {
        }

        [ScriptAlias("QUnit.expect")]
        public static void ExpectAsserts(int assertions) {
        }

        [ScriptAlias("QUnit.ok")]
        public static void IsTrue(bool condition) {
        }

        [ScriptAlias("QUnit.ok")]
        public static void IsTrue(bool condition, string message) {
        }
    }
}
