// TypeSystemTests.cs
// Script#/Tests
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ScriptSharp.Tests.Core;

namespace ScriptSharp.Tests {

    [TestClass]
    public class ScriptTests : BrowserTest {

        [TestMethod]
        public void TestGlobals() {
            RunTest("/Globals.htm");
        }

        [TestMethod]
        public void TestTypeSystem() {
            RunTest("/TypeSystem.htm");
        }

        [TestMethod]
        public void TestBases() {
            RunTest("/Bases.htm");
        }

        [TestMethod]
        public void TestParamsGenerator()
        {
            RunTest("/ParamsGenerator.htm");
        }

        [TestMethod]
        public void TestProperties()
        {
            RunTest("/Properties.htm");
        }

        #region Loader Tests
        [TestMethod]
        public void TestLoader() {
            RunTest("/Loader.htm");
        }

        [TestMethod]
        public void TestLoaderChain() {
            RunTest("/LoaderChain.htm");
        }

        [TestMethod]
        public void TestLoaderCombined() {
            RunTest("/LoaderCombined.htm");
        }

        [TestMethod]
        public void TestLoaderConfig() {
            RunTest("/LoaderConfig.htm");
        }

        [TestMethod]
        public void TestLoaderNonAMD() {
            RunTest("/LoaderNonAMD.htm");
        }
        #endregion

        #region BCL Tests
        [TestMethod]
        public void TestDate() {
            RunTest("/Date.htm");
        }

        [TestMethod]
        public void TestDelegates() {
            RunTest("/Delegates.htm");
        }

        [TestMethod]
        public void TestString() {
            RunTest("/String.htm");
        }

        [TestMethod]
        public void TestStringBuilder() {
            RunTest("/StringBuilder.htm");
        }

        [TestMethod]
        public void TestDictionary() {
            RunTest("/Dictionary.htm");
        }

        [TestMethod]
        public void TestQueue() {
            RunTest("/Queue.htm");
        }

        [TestMethod]
        public void TestStack() {
            RunTest("/Stack.htm");
        }

        [TestMethod]
        public void TestEnumerator() {
            RunTest("/Enumerator.htm");
        }

        [TestMethod]
        public void TestObservable() {
            RunTest("/Observable.htm");
        }

        [TestMethod]
        public void TestTasks() {
            RunTest("/Tasks.htm");
        }
        #endregion
    }
}
