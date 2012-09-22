// BCLTests.cs
// Script#/Tests/Runtime
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Runtime.Tests.Core;

namespace Runtime.Tests {

    [TestClass]
    public class BCLTests : RuntimeTest {

        [TestMethod]
        public void TestDictionary() {
            RunTest("/TestDictionary.htm");
        }

        [TestMethod]
        public void TestEnumerator() {
            RunTest("/TestEnumerator.htm");
        }

        [TestMethod]
        public void TestObservable() {
            RunTest("/TestObservable.htm");
        }

        [TestMethod]
        public void TestQueue() {
            RunTest("/TestQueue.htm");
        }

        [TestMethod]
        public void TestStack() {
            RunTest("/TestStack.htm");
        }

        [TestMethod]
        public void TestStringBuilder() {
            RunTest("/TestStringBuilder.htm");
        }

        [TestMethod]
        public void TestTasks() {
            RunTest("/TestTasks.htm");
        }
    }
}
