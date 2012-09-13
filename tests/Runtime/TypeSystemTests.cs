// TypeSystemTests.cs
// Script#/Tests/Runtime
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Runtime.Tests.Core;

namespace Runtime.Tests {

    [TestClass]
    public class TypeSystemTests : RuntimeTest {

        [TestMethod]
        public void TestOOP() {
            RunTest("/TestOOP.htm");
        }
    }
}
