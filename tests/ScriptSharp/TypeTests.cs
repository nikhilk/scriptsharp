// TypeTests.cs
// Script#/Tests/ScriptSharp
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ScriptSharp.Tests.Core;

namespace ScriptSharp.Tests {

    [TestClass]
    public sealed class TypeTests : CompilationTest {

        [TestMethod]
        public void TestClasses() {
            RunTest((c) => {
                c.AddSource("Code.cs");
            });
        }

        [TestMethod]
        public void TestDelegates() {
            RunTest((c) => {
                c.AddSource("Code.cs");
            });
        }

        [TestMethod]
        public void TestEnumerator() {
            RunTest((c) => {
                c.AddSource("Code.cs");
            });
        }

        [TestMethod]
        public void TestEnums() {
            RunTest((c) => {
                c.AddSource("Code.cs");
            });
        }

        [TestMethod]
        public void TestGlobals() {
            RunTest((c) => {
                c.AddSource("Code.cs");
            });
        }

        [TestMethod]
        public void TestImported() {
            RunTest((c) => {
                c.AddReference("Script.Web.dll").
                  AddSource("Code.cs");
            });
        }

        [TestMethod]
        public void TestInterfaces() {
            RunTest((c) => {
                c.AddSource("Code.cs");
            });
        }

        [TestMethod]
        public void TestNamespaces() {
            RunTest((c) => {
                c.AddSource("Code.cs");
            });
        }

        [TestMethod]
        public void TestModules() {
            RunTest((c) => {
                c.AddReference("Script.Web.dll").
                  AddSource("Code.cs");
                c.Options.Defines = new string[] { "INCLUDE_EXPORT" };
            });

            RunTest((c) => {
                c.AddReference("Script.Web.dll").
                  AddSource("Code.cs");
            }, "ZeroExportsBaseline.txt");
        }

        [TestMethod]
        public void TestNullable() {
            RunTest((c) => {
                c.AddSource("Code.cs");
            });
        }

        [TestMethod]
        public void TestPartials() {
            RunTest((c) => {
                c.AddReference("Script.Web.dll").
                  AddSource("Code1.cs").
                  AddSource("Code2.cs");
            });
        }

        [TestMethod]
        public void TestRecords() {
            RunTest((c) => {
                c.AddSource("Code.cs");
            });
        }

        [TestMethod]
        public void TestUsingAlias() {
            RunTest((c) => {
                c.AddReference("Script.Web.dll").
                  AddSource("Code.cs");
            });
        }
    }
}
