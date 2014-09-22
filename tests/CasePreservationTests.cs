// CasePreservationTests.cs
// Script#/Tests
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ScriptSharp.Tests.Core;

namespace ScriptSharp.Tests {

    [TestClass]
    public class CasePreservationTests :  CompilationTest {

        [TestMethod]
        public void TestDefaultCase() {
            RunTest((c) => {
                c.AddSource("Code.cs");
            });
        }

        [TestMethod]
        public void TestAllMembersCasePreserved() {
            RunTest((c) => {
                c.AddSource("Code.cs");
            });
        }

        [TestMethod]
        public void TestNoMemberCasePreserved() {
            RunTest((c) => {
                c.AddSource("Code.cs");
            });
        }

        [TestMethod]
        public void TestOneTypesMembersCaseNotPreserved() {
            RunTest((c) => {
                c.AddSource("Code.cs");
            });
        }

        [TestMethod]
        public void TestOneMemberCaseNotPreserved() {
            RunTest((c) => {
                c.AddSource("Code.cs");
            });
        }
    }
}
