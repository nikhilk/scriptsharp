// BasicTests.cs
// Script#/Tests/ScriptSharp
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.IO;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ScriptSharp.Generators;
using ScriptSharp.Tests.Core;

namespace ScriptSharp.Tests {

    [TestClass]
    public sealed class BasicTests : CompilationTest {

        [TestMethod]
        public void TestAssemblies()
        {
            RunTest((c) =>
            {
                c.AddSource("Code.cs");
            }, "Baseline.js");
        }

        [TestMethod]
        public void TestLists()
        {
            RunTest((c) =>
            {
                c.AddSource("Code.cs");
                c.Options.Defines = new string[] { "DEBUG" };
            }, "Baseline.txt");
        }

        [TestMethod]
        public void TestGuid()
        {
            RunTest((c) =>
            {
                c.AddSource("Code.cs");
                c.Options.Defines = new string[] { "DEBUG" };
            }, "Baseline.txt");
        }

        [TestMethod]
        public void TestConditionals() {
            RunTest((c) => {
                c.AddSource("Code.cs");
                c.Options.Defines = new string[] { "DEBUG" };
            }, "DebugBaseline.txt");

            RunTest((c) => {
                c.AddSource("Code.cs");
                c.Options.Defines = new string[] { "TRACE" };
            }, "TraceBaseline.txt");
        }

        [TestMethod]
        public void TestDependencies() {
            RunTest((c) => {
                c.AddReference("Lib1.dll").
                  AddReference("Lib2.dll").
                  AddReference("Lib3.dll").
                  AddSource("Code1.cs");
            }, "Code1Baseline.txt");

            RunTest((c) => {
                c.AddReference("Lib1.dll").
                  AddReference("Lib2.dll").
                  AddReference("Lib3.dll").
                  AddSource("Code2.cs");
            }, "Code2Baseline.txt");

            RunTest((c) => {
                c.AddReference("Script.Web.dll").
                  AddReference("Lib1.dll").
                  AddReference("Lib2.dll").
                  AddReference("Lib3.dll").
                  AddSource("Code3.cs");
            }, "Code3Baseline.txt");

            RunTest((c) => {
                c.AddReference("Script.Web.dll").
                  AddReference("Lib1.dll").
                  AddReference("Lib2.dll").
                  AddReference("Lib3.dll").
                  AddSource("Code4.cs");
            }, "Code4Baseline.txt");
        }

        [TestMethod]
        public void TestDocComments() {
            RunTest((c) => {
                c.AddReference("Script.Web.dll").
                  AddSource("Code.cs").
                  AddComments("DocComments.xml");
            });
        }

        [TestMethod]
        public void TestFlags() {
            RunTest((c) => {
                c.AddSource("Code.cs");
                c.Options.Defines = new string[] { "ABC" };
            });
        }

        [TestMethod]
        public void TestIncludes() {
            RunTest((c) => {
                c.AddSource("Code.cs");
            }, "ZeroIncBaseline.txt");

            RunTest((c) => {
                c.AddSource("Code.cs").
                  AddIncludeResolver();
            }, "SingleIncBaseline.txt");

            RunTest((c) => {
                c.AddSource("Code.cs").
                  AddIncludeResolver();
                c.Options.Defines = new string[] { "MULTIPLE_INCLUDE" };
            }, "MultipleIncBaseline.txt");
        }

        [TestMethod]
        public void TestMetadata() {
            RunTest((c) => {
                c.AddReference("Lib.dll").
                  AddSource("Code.cs");
                c.Options.InternalTestType = "metadata";
            });
        }

        [TestMethod]
        public void TestMinimization() {
            RunTest((c) => {
                c.AddReference("Script.Web.dll").
                  AddReference("Lib.dll").
                  AddSource("Code.cs");
                c.Options.Minimize = true;
                c.Options.InternalTestType = "minimizationMap";
            });
        }

        [TestMethod]
        public void TestResources() {
            string resource1Path = GetTestFilePath("Strings1.resx");
            string resource2Path = GetTestFilePath("Strings2.resx");

            string resource1Markup = File.ReadAllText(resource1Path);
            string resource2Markup = File.ReadAllText(resource2Path);

            ResXCodeBuilder resxCodeBuilder = new ResXCodeBuilder();

            resxCodeBuilder.Start("Resources");
            resxCodeBuilder.GenerateCode("Strings1.resx", resource1Markup, null);
            string code1 = resxCodeBuilder.End();

            resxCodeBuilder.Start("Resources");
            resxCodeBuilder.GenerateCode("Strings2.resx", resource2Markup, "PublicResxScriptGenerator");
            string code2 = resxCodeBuilder.End();

            RunTest((c) => {
                c.AddSource("Code.cs").
                  AddCode("Strings1.Designer.cs", code1).
                  AddCode("Strings2.Designer.cs", code2).
                  AddResource("Strings1.resx").
                  AddResource("Strings1.fr.resx").
                  AddResource("Strings1.fr-FR.resx").
                  AddResource("Strings2.resx");
                c.Options.Defines = new string[] { "DEBUG" };
            });
        }

        [TestMethod]
        public void TestSimple() {
            RunTest((c) => {
                c.AddSource("Code.cs");
            }, "DefaultBaseline.txt");

            RunTest((c) => {
                c.AddSource("Code.cs");
                c.Options.Defines = new string[] { "SIMPLE_TEMPLATE" };
            }, "SimpleBaseline.txt");

            RunTest((c) => {
                c.AddSource("Code.cs");
                c.Options.Defines = new string[] { "AMD_TEMPLATE" };
            }, "AMDBaseline.txt");
        }

        [TestMethod]
        public void TestUnitTest() {
            RunTest((c) => {
                c.AddSource("Code.cs");
            }, "NonTestBaseline.txt");

            RunTest((c) => {
                c.AddSource("Code.cs");
                c.Options.IncludeTests = true;
            }, "TestBaseline.txt");
        }
    }
}
