// LibraryTests.cs
// Script#/Tests/ScriptSharp
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ScriptSharp.Tests.Core;

namespace ScriptSharp.Tests {

    [TestClass]
    public sealed class LibraryTests : CompilationTest {

        [TestMethod]
        public void TestjQuery() {
            RunTest((c) => {
                c.AddReference("Script.Web.dll").
                  AddReference("Script.jQuery.dll").
                  AddSource("Code.cs");
                c.Options.Defines = new string[] { "DEBUG" };
            });
        }

        [TestMethod]
        public void TestNode() {
            RunTest((c) => {
                c.AddReference("Script.Node.dll").
                  AddSource("Code.cs");
            });
        }
    }
}
