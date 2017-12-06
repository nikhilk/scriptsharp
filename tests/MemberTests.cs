// MemberTests.cs
// Script#/Tests/ScriptSharp
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ScriptSharp.Tests.Core;

namespace ScriptSharp.Tests {

    [TestClass]
    public sealed class MemberTests : CompilationTest {

        [TestMethod]
        public void TestConstructors() {
            RunTest((c) => {
                c.AddSource("Code.cs");
            });
        }

        [TestMethod]
        public void TestEvents() {
            RunTest((c) => {
                c.AddSource("Code.cs");
            });
        }

        [TestMethod]
        public void TestFields() {
            RunTest((c) => {
                c.AddSource("Code.cs");
            });
        }

        [TestMethod]
        public void TestIndexers() {
            RunTest((c) => {
                c.AddSource("Code.cs");
            });
        }

        [TestMethod]
        public void TestMethods() {
            RunTest((c) => {
                c.AddReference("Script.Web.dll")
                 .AddSource("Code.cs");
            });
        }

        [TestMethod]
        public void TestProperties() {
            RunTest((c) => {
                c.AddSource("Code.cs");
            });
        }

        [TestMethod]
        public void TestOverloads() {
            RunTest((c) => {
                c.AddSource("Code.cs");
            });
        }

        [TestMethod]
        public void TestStaticConstructors() {
            RunTest((c) => {
                c.AddReference("Script.Web.dll").
                  AddSource("Code.cs");
            });
        }

        [TestMethod]
        public void TestStaticConstructorsPrivateInstance()
        {
            RunTest((c) => {
                c.AddSource("Code.cs");
            });
        }
    }
}
