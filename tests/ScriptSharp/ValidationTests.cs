// ValidationTests.cs
// Script#/Tests/ScriptSharp
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ScriptSharp.Tests.Core;

namespace ScriptSharp.Tests {

    [TestClass]
    public sealed class ValidationTests : CompilationTest {

        [TestMethod]
        public void TestConflictingTypes() {
            string expectedErrors =
                "The type 'test.App' conflicts with another existing type with the same full name. " +
                "This might be because a referenced assembly uses the same type, or you have multiple " +
                "types with the same name across namespaces mapped to the same script namespace. ";

            Compilation compilation = CreateCompilation();
            compilation.AddSource("Code.cs");

            bool result = compilation.Execute();
            Assert.IsFalse(result, "Expected compilation to fail.");

            Assert.IsTrue(compilation.HasErrors, "Expected compilation to fail with errors.");
            if (String.CompareOrdinal(compilation.ErrorMessages, expectedErrors) != 0) {
                Console.WriteLine("Expected Errors:");
                Console.WriteLine(expectedErrors);
                Console.WriteLine();
                Console.WriteLine("Actual Errors:");
                Console.WriteLine(compilation.ErrorMessages);
                Console.WriteLine();

                Assert.Fail("Unexpected errors.");
            }
        }

        [TestMethod]
        public void TestCreateInstance() {
            string expectedErrors =
                "You must store the type returned from a method or property into a local variable to use with Type.CreateInstance. Code.cs(37, 25)" + Environment.NewLine +
                "You must store the type returned from a method or property into a local variable to use with Type.CreateInstance. Code.cs(38, 25)";

            Compilation compilation = CreateCompilation();
            compilation.AddSource("Code.cs");

            bool result = compilation.Execute();
            Assert.IsFalse(result, "Expected compilation to fail.");

            Assert.IsTrue(compilation.HasErrors, "Expected compilation to fail with errors.");
            if (String.CompareOrdinal(compilation.ErrorMessages, expectedErrors) != 0) {
                Console.WriteLine("Expected Errors:");
                Console.WriteLine(expectedErrors);
                Console.WriteLine();
                Console.WriteLine("Actual Errors:");
                Console.WriteLine(compilation.ErrorMessages);
                Console.WriteLine();

                Assert.Fail("Unexpected errors.");
            }
        }

        [TestMethod]
        public void TestExceptions() {
            string expectedErrors =
                "Try/Catch statements are limited to a single catch clause. Code.cs(12, 13)" + Environment.NewLine +
                "Throw statements must specify an exception object. Code.cs(26, 17)";

            Compilation compilation = CreateCompilation();
            compilation.AddSource("Code.cs");

            bool result = compilation.Execute();
            Assert.IsFalse(result, "Expected compilation to fail.");

            Assert.IsTrue(compilation.HasErrors, "Expected compilation to fail with errors.");
            if (String.CompareOrdinal(compilation.ErrorMessages, expectedErrors) != 0) {
                Console.WriteLine("Expected Errors:");
                Console.WriteLine(expectedErrors);
                Console.WriteLine();
                Console.WriteLine("Actual Errors:");
                Console.WriteLine(compilation.ErrorMessages);
                Console.WriteLine();

                Assert.Fail("Unexpected errors.");
            }
        }

        [TestMethod]
        public void TestImplicitEnums() {
            string expectedErrors =
                "Enumeration fields must have an explicit constant value specified. Code.cs(13, 9)";

            Compilation compilation = CreateCompilation();
            compilation.AddSource("Code.cs");

            bool result = compilation.Execute();
            Assert.IsFalse(result, "Expected compilation to fail.");

            Assert.IsTrue(compilation.HasErrors, "Expected compilation to fail with errors.");
            if (String.CompareOrdinal(compilation.ErrorMessages, expectedErrors) != 0) {
                Console.WriteLine("Expected Errors:");
                Console.WriteLine(expectedErrors);
                Console.WriteLine();
                Console.WriteLine("Actual Errors:");
                Console.WriteLine(compilation.ErrorMessages);
                Console.WriteLine();

                Assert.Fail("Unexpected errors.");
            }
        }

        [TestMethod]
        public void TestInlineScript() {
            string expectedErrors =
                "The argument to Script.Literal must be a constant string. Code.cs(15, 28)";

            Compilation compilation = CreateCompilation();
            compilation.AddSource("Code.cs");

            bool result = compilation.Execute();
            Assert.IsFalse(result, "Expected compilation to fail.");

            Assert.IsTrue(compilation.HasErrors, "Expected compilation to fail with errors.");
            if (String.CompareOrdinal(compilation.ErrorMessages, expectedErrors) != 0) {
                Console.WriteLine("Expected Errors:");
                Console.WriteLine(expectedErrors);
                Console.WriteLine();
                Console.WriteLine("Actual Errors:");
                Console.WriteLine(compilation.ErrorMessages);
                Console.WriteLine();

                Assert.Fail("Unexpected errors.");
            }
        }

        [TestMethod]
        public void TestKeywords() {
            string expectedErrors =
                "ss is a reserved word. Code.cs(12, 17)" + Environment.NewLine +
                "instanceof is a reserved word. Code.cs(16, 17)";

            Compilation compilation = CreateCompilation();
            compilation.AddSource("Code.cs");

            bool result = compilation.Execute();
            Assert.IsFalse(result, "Expected compilation to fail.");

            Assert.IsTrue(compilation.HasErrors, "Expected compilation to fail with errors.");
            if (String.CompareOrdinal(compilation.ErrorMessages, expectedErrors) != 0) {
                Console.WriteLine("Expected Errors:");
                Console.WriteLine(expectedErrors);
                Console.WriteLine();
                Console.WriteLine("Actual Errors:");
                Console.WriteLine(compilation.ErrorMessages);
                Console.WriteLine();

                Assert.Fail("Unexpected errors.");
            }
        }

        [TestMethod]
        public void TestNestedTypes() {
            string expectedErrors =
                "Only members are allowed inside types. Nested types are not supported. Code.cs(9, 5)" + Environment.NewLine +
                "Only members are allowed inside types. Nested types are not supported. Code.cs(9, 5)";

            Compilation compilation = CreateCompilation();
            compilation.AddSource("Code.cs");

            bool result = compilation.Execute();
            Assert.IsFalse(result, "Expected compilation to fail.");

            Assert.IsTrue(compilation.HasErrors, "Expected compilation to fail with errors.");
            if (String.CompareOrdinal(compilation.ErrorMessages, expectedErrors) != 0) {
                Console.WriteLine("Expected Errors:");
                Console.WriteLine(expectedErrors);
                Console.WriteLine();
                Console.WriteLine("Actual Errors:");
                Console.WriteLine(compilation.ErrorMessages);
                Console.WriteLine();

                Assert.Fail("Unexpected errors.");
            }
        }

        [TestMethod]
        public void TestOverloads() {
            string expectedErrors =
                "Extern methods used to declare alternate signatures should have a corresponding non-extern implementation as well. Code.cs(11, 9)" + Environment.NewLine +
                "The implemenation method and associated alternate signature methods should have the same access type. Code.cs(14, 9)" + Environment.NewLine +
                "The implemenation method and associated alternate signature methods should have the same access type. Code.cs(17, 9)";

            Compilation compilation = CreateCompilation();
            compilation.AddSource("Code.cs");

            bool result = compilation.Execute();
            Assert.IsFalse(result, "Expected compilation to fail.");

            Assert.IsTrue(compilation.HasErrors, "Expected compilation to fail with errors.");
            if (String.CompareOrdinal(compilation.ErrorMessages, expectedErrors) != 0) {
                Console.WriteLine("Expected Errors:");
                Console.WriteLine(expectedErrors);
                Console.WriteLine();
                Console.WriteLine("Actual Errors:");
                Console.WriteLine(compilation.ErrorMessages);
                Console.WriteLine();

                Assert.Fail("Unexpected errors.");
            }
        }

        [TestMethod]
        public void TestProperties() {
            string expectedErrors =
                "Set-only properties are not supported. Use a set method instead. Code.cs(11, 9)";

            Compilation compilation = CreateCompilation();
            compilation.AddSource("Code.cs");

            bool result = compilation.Execute();
            Assert.IsFalse(result, "Expected compilation to fail.");

            Assert.IsTrue(compilation.HasErrors, "Expected compilation to fail with errors.");
            if (String.CompareOrdinal(compilation.ErrorMessages, expectedErrors) != 0) {
                Console.WriteLine("Expected Errors:");
                Console.WriteLine(expectedErrors);
                Console.WriteLine();
                Console.WriteLine("Actual Errors:");
                Console.WriteLine(compilation.ErrorMessages);
                Console.WriteLine();

                Assert.Fail("Unexpected errors.");
            }
        }

        [TestMethod]
        public void TestUnsupported() {
            string expectedErrors1 =
                "Type destructors are not supported. Code1.cs(14, 9)" + Environment.NewLine +
                "Using statements are not supported. Code1.cs(18, 13)" + Environment.NewLine +
                "Derived interface types are not supported. Code1.cs(26, 5)";

            string expectedErrors2 =
                "Check that your C# source compiles and that you are not using an unsupported feature. Common things to check for include use of fully-qualified names (use a using statement to import namespaces instead) or accessing private members of a type from a static member of the same type. Code2.cs(12, 13)";

            Compilation compilation1 = CreateCompilation();
            compilation1.AddSource("Code1.cs");

            bool result1 = compilation1.Execute();
            Assert.IsFalse(result1, "Expected compilation to fail.");

            Assert.IsTrue(compilation1.HasErrors, "Expected compilation to fail with errors.");
            if (String.CompareOrdinal(compilation1.ErrorMessages, expectedErrors1) != 0) {
                Console.WriteLine("Expected Errors:");
                Console.WriteLine(expectedErrors1);
                Console.WriteLine();
                Console.WriteLine("Actual Errors:");
                Console.WriteLine(compilation1.ErrorMessages);
                Console.WriteLine();

                Assert.Fail("Unexpected errors.");
            }

            Compilation compilation2 = CreateCompilation();
            compilation2.AddSource("Code2.cs");

            bool result2 = compilation2.Execute();
            Assert.IsFalse(result2, "Expected compilation to fail.");

            Assert.IsTrue(compilation2.HasErrors, "Expected compilation to fail with errors.");
            if (String.CompareOrdinal(compilation2.ErrorMessages, expectedErrors2) != 0) {
                Console.WriteLine("Expected Errors:");
                Console.WriteLine(expectedErrors2);
                Console.WriteLine();
                Console.WriteLine("Actual Errors:");
                Console.WriteLine(compilation2.ErrorMessages);
                Console.WriteLine();

                Assert.Fail("Unexpected errors.");
            }
        }
    }
}
