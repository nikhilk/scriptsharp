// StatementTests.cs
// Script#/Tests/ScriptSharp
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ScriptSharp.Tests.Core;

namespace ScriptSharp.Tests {

    [TestClass]
    public sealed class StatementTests : CompilationTest {

        [TestMethod]
        public void TestExceptions() {
            RunTest((c) => {
                c.AddSource("Code.cs");
            });
        }

        [TestMethod]
        public void TestExpression() {
            RunTest((c) => {
                c.AddSource("Code.cs");
            });
        }

        [TestMethod]
        public void TestFor() {
            RunTest((c) => {
                c.AddSource("Code.cs");
            });
        }

        [TestMethod]
        public void TestForeach() {
            RunTest((c) => {
                c.AddSource("Code.cs");
            });
        }

        [TestMethod]
        public void TestIfElse() {
            RunTest((c) => {
                c.AddSource("Code.cs");
            });
        }

        [TestMethod]
        public void TestReturn() {
            RunTest((c) => {
                c.AddSource("Code.cs");
            });
        }

        [TestMethod]
        public void TestSwitch() {
            RunTest((c) => {
                c.AddSource("Code.cs");
            });
        }

        [TestMethod]
        public void TestUsing()
        {
            RunTest((c) =>
            {
                c.AddSource("Code.cs");
            });
        }

        [TestMethod]
        public void TestVariables() {
            RunTest((c) => {
                c.AddSource("Code.cs");
            });
        }

        [TestMethod]
        public void TestWhile() {
            RunTest((c) => {
                c.AddSource("Code.cs");
            });
        }
    }
}
