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
                c.Options.DebugFlavor = true;
            });
        }

        [TestMethod]
        public void TestDelegates() {
            RunTest((c) => {
                c.AddSource("Code.cs");
                c.Options.DebugFlavor = true;
            });
        }

        [TestMethod]
        public void TestEnumerator() {
            RunTest((c) => {
                c.AddSource("Code.cs");
                c.Options.DebugFlavor = true;
            });
        }

        [TestMethod]
        public void TestEnums() {
            RunTest((c) => {
                c.AddSource("Code.cs");
                c.Options.DebugFlavor = true;
            });
        }

        [TestMethod]
        public void TestGlobals() {
            RunTest((c) => {
                c.AddSource("Code.cs");
                c.Options.DebugFlavor = true;
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
                c.Options.DebugFlavor = true;
            });
        }

        [TestMethod]
        public void TestNamespaces() {
            RunTest((c) => {
                c.AddSource("Code.cs");
                c.Options.DebugFlavor = true;
            });
        }

        [TestMethod]
        public void TestNullable() {
            RunTest((c) => {
                c.AddSource("Code.cs");
                c.Options.DebugFlavor = true;
            });
        }

        [TestMethod]
        public void TestPartials() {
            RunTest((c) => {
                c.AddReference("Script.Web.dll").
                  AddSource("Code1.cs").
                  AddSource("Code2.cs");
                c.Options.DebugFlavor = true;
            });
        }

        [TestMethod]
        public void TestRecords() {
            RunTest((c) => {
                c.AddSource("Code.cs");
                c.Options.DebugFlavor = true;
            });
        }

        [TestMethod]
        public void TestScriptNamespaces() {
            RunTest((c) => {
                c.AddSource("LibraryAssemblyInfo.cs").
                  AddSource("LibraryFeature.cs").
                  AddSource("LibraryMyLib.cs");
                c.Options.DebugFlavor = true;
            }, "LibraryBaseline.txt");

            RunTest((c) => {
                c.AddReference("Lib.dll").
                  AddSource("AppAssemblyInfo.cs").
                  AddSource("AppFeature.cs").
                  AddSource("AppMyApp.cs").
                  AddSource("AppFoo.1.cs").
                  AddSource("AppFoo.2.cs");
                c.Options.DebugFlavor = true;
            }, "AppBaseline.txt");
        }

        [TestMethod]
        public void TestUsingAlias() {
            RunTest((c) => {
                c.AddReference("Script.Web.dll").
                  AddSource("Code.cs");
                c.Options.DebugFlavor = true;
            });
        }
    }
}
