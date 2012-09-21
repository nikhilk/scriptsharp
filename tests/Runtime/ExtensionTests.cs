// ExtensionTests.cs
// Script#/Tests/Runtime
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Runtime.Tests.Core;

namespace Runtime.Tests {

    [TestClass]
    public class ExtensionTests : RuntimeTest {

        [TestMethod]
        public void TestArray() {
            RunTest("/TestArray.htm");
        }

        [TestMethod]
        public void TestString() {
            RunTest("/TestString.htm");
        }
    }
}
