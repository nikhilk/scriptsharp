// ExpressionTests.cs
// Script#/Tests/ScriptSharp
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ScriptSharp.Tests.Core;

namespace ScriptSharp.Tests {

    [TestClass]
    public sealed class ExpressionTests : CompilationTest {

        [TestMethod]
        public void TestAnonymousMethods() {
            RunTest((c) => {
                c.AddSource("Code.cs");
            });
        }

        [TestMethod]
        public void TestArguments() {
            RunTest((c) => {
                c.AddSource("Code.cs");
            });
        }

        [TestMethod]
        public void TestArray() {
            RunTest((c) => {
                c.AddSource("Code.cs");
            });
        }

        [TestMethod]
        public void TestBase() {
            RunTest((c) => {
                c.AddSource("Code.cs");
            });
        }

        [TestMethod]
        public void TestBinary() {
            RunTest((c) => {
                c.AddSource("Code.cs");
            });
        }

        [TestMethod]
        public void TestCast() {
            RunTest((c) => {
                c.AddSource("Code.cs");
            });
        }

        [TestMethod]
        public void TestConditional() {
            RunTest((c) => {
                c.AddSource("Code.cs");
            });
        }

        [TestMethod]
        public void TestDate() {
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
        public void TestDictionary() {
            RunTest((c) => {
                c.AddSource("Code.cs");
            });
        }

        [TestMethod]
        public void TestEnumToString() {
            RunTest((c) => {
                c.AddSource("Code1.cs");
            }, "NormalBaseline.txt");

            RunTest((c) => {
                c.AddSource("Code2.cs");
                c.Options.Minimize = true;
            }, "MinBaseline.txt");
        }

        [TestMethod]
        public void TestEvents() {
            RunTest((c) => {
                c.AddSource("Code.cs");
            });
        }

        [TestMethod]
        public void TestExtensionMethods() {
            RunTest((c) => {
                c.AddSource("Code.cs");
            });
        }

        [TestMethod]
        public void TestGenerics() {
            RunTest((c) => {
                c.AddReference("Script.Web.dll").
                  AddReference("Script.jQuery.dll").
                  AddSource("Code.cs");
            });
        }

        [TestMethod]
        public void TestGetType() {
            RunTest((c) => {
                c.AddSource("Code.cs");
            });
        }

        [TestMethod]
        public void TestInlineScript() {
            RunTest((c) => {
                c.AddSource("Code.cs");
            });
        }

        [TestMethod]
        public void TestLateBound() {
            RunTest((c) => {
                c.AddSource("Code.cs");
            });
        }

        [TestMethod]
        public void TestLiterals() {
            RunTest((c) => {
                c.AddSource("Code.cs");
            });
        }

        [TestMethod]
        public void TestLocals() {
            RunTest((c) => {
                c.AddSource("Code.cs");
            });
        }

        [TestMethod]
        public void TestMembers() {
            RunTest((c) => {
                c.AddSource("Code.cs");
            });
        }

        [TestMethod]
        public void TestNew() {
            RunTest((c) => {
                c.AddSource("Code.cs");
            });
        }

        [TestMethod]
        public void TestNumber() {
            RunTest((c) => {
                c.AddSource("Code.cs");
            });
        }

        [TestMethod]
        public void TestScript() {
            RunTest((c) => {
                c.AddSource("Code.cs");
            });
        }

        [TestMethod]
        public void TestString() {
            RunTest((c) => {
                c.AddSource("Code.cs");
            });
        }

        [TestMethod]
        public void TestTasks() {
            RunTest((c) => {
                c.AddSource("Code.cs");
            });
        }

        [TestMethod]
        public void TestTruthy() {
            RunTest((c) => {
                c.AddSource("Code.cs");
            });
        }

        [TestMethod]
        public void TestTuples() {
            RunTest((c) => {
                c.AddSource("Code.cs");
            });
        }

        [TestMethod]
        public void TestUnary() {
            RunTest((c) => {
                c.AddSource("Code.cs");
            });
        }
    }
}
