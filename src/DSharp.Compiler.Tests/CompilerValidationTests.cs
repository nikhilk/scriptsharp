using System;
using System.Collections.Generic;
using System.Linq;
using DSharp.Compiler.Errors;
using DSharp.Compiler.TestFramework.Compilation;
using DSharp.Compiler.TestFramework.Context;
using DSharp.Compiler.Tests.Fixtures;
using Xunit;

namespace DSharp.Compiler.Tests
{
    public class CompilerValidationTests : IClassFixture<TestContextFixture>
    {
        private static readonly IDictionary<string, Action<IEnumerable<CompilerError>>> compilerErrorTestFunctions;

        private readonly TestContextFixture compilerCompliationFixture;

        private ICompilationUnitFactory CompilationUnitFactory => compilerCompliationFixture?.CompilationUnitFactory;

        private ITestContextFactory TestContextFactory => compilerCompliationFixture?.TestContextFactory;

        static CompilerValidationTests()
        {
            compilerErrorTestFunctions = new Dictionary<string, Action<IEnumerable<CompilerError>>>()
            {
                ["ConflictingTypes"] = CreateContainsErrorsFunction(
                    new CompilerError(
                        (ushort)CompilerErrorCode.GeneralError, 
                        string.Format(DSharpStringResources.CONFLICTING_TYPE_NAME_ERROR_FORMAT, "SomeOtherNameSpace.App", "ValidationTests.App"))),
                ["Exceptions"] = CreateContainsErrorMessagesFunction(
                    DSharpStringResources.NODE_VALIDATION_ERROR_TRY_CATCH,
                    DSharpStringResources.THROW_NODE_VALIDATION_ERROR),
                ["ImplicitEnums"] = CreateContainsErrorMessagesFunction(
                    DSharpStringResources.ENUM_CONSTANT_VALUE_MISSING_ERROR,
                    DSharpStringResources.ENUM_VALUE_TYPE_ERROR),
                ["InlineScript"] = CreateContainsErrorMessagesFunction(
                    DSharpStringResources.SCRIPT_LITERAL_CONSTANT_ERROR,
                    DSharpStringResources.SCRIPT_LITERAL_FORMAT_ERROR),
                ["Keywords"] = CreateContainsErrorMessagesFunction(
                    string.Format(DSharpStringResources.RESERVED_KEYWORD_ERROR_FORMAT, DSharpStringResources.DSHARP_SCRIPT_NAME),
                    string.Format(DSharpStringResources.RESERVED_KEYWORD_ERROR_FORMAT, "instanceof")
                    ),
                ["PrivateNestedTypes"] = CreateContainsErrorMessagesFunction(
                    DSharpStringResources.ACCESS_MODIFIER_ON_TYPE_UNSUPPORTED,
                    DSharpStringResources.ACCESS_MODIFIER_ON_TYPE_UNSUPPORTED,
                    DSharpStringResources.ACCESS_MODIFIER_ON_TYPE_UNSUPPORTED
                    ),
                ["ProtectedNestedTypes"] = CreateContainsErrorMessagesFunction(
                    DSharpStringResources.ACCESS_MODIFIER_ON_TYPE_UNSUPPORTED,
                    DSharpStringResources.ACCESS_MODIFIER_ON_TYPE_UNSUPPORTED,
                    DSharpStringResources.ACCESS_MODIFIER_ON_TYPE_UNSUPPORTED
                    ),
                ["NewKeywordOnType"] = CreateContainsErrorMessagesFunction(
                    DSharpStringResources.NEW_KEYWORD_ON_TYPE_UNSUPPORTED,
                    DSharpStringResources.NEW_KEYWORD_ON_TYPE_UNSUPPORTED,
                    DSharpStringResources.NEW_KEYWORD_ON_TYPE_UNSUPPORTED
                    ),
                ["Overloads"] = CreateContainsErrorMessagesFunction(
                    DSharpStringResources.EXTERN_IMPLEMENTATION_FOUND_ERROR,
                    DSharpStringResources.EXTERN_STATIC_MEMBER_MISMATCH_ERROR,
                    DSharpStringResources.EXTERN_STATIC_MEMBER_MISMATCH_ERROR
                    ),
                ["Records"] = CreateContainsErrorMessagesFunction(
                    DSharpStringResources.SCRIPT_OBJECT_ATTRIBUTE_ERROR,
                    DSharpStringResources.SCRIPT_OBJECT_CLASS_INHERITENCE_ERROR,
                    DSharpStringResources.SCRIPT_OBJECT_MEMBER_VIOLATION_ERROR,
                    DSharpStringResources.SCRIPT_OBJECT_MEMBER_VIOLATION_ERROR
                    ),
            };
        }

        public CompilerValidationTests(TestContextFixture compilerCompliationFixture)
        {
            this.compilerCompliationFixture = compilerCompliationFixture;
        }

        //TODO: Need to add more specific tests to validate the message and the location of the error in the file.
        [Theory(DisplayName = "Compiler Error Validation")]
        [MemberData(nameof(TestCompilerErrorsData))]
        public void TestCompilerErrors(string testName)
        {
            IList<string> sourceFiles = TestContextFactory.GetTestSourceFiles("Validation", testName);
            ICompilationUnit compilationUnit = CompilationUnitFactory.CreateCompilationUnitBuilder()
                .AddSourceFiles(sourceFiles.ToArray())
                .Build();

            bool compilationSuccess = compilationUnit.Compile(out ICompilationUnitResult compilationUnitResult);
            Assert.False(compilationSuccess, "Expected compilation to fail");

            compilerErrorTestFunctions.TryGetValue(testName, out Action<IEnumerable<CompilerError>> compilerErrorResultValidator);

            compilerErrorResultValidator.Invoke(compilationUnitResult.Errors);
        }
        public static IEnumerable<object[]> TestCompilerErrorsData
        {
            get { return compilerErrorTestFunctions.Keys.Select(key => new object[] { key }); }
        }

        private static Action<IEnumerable<CompilerError>> CreateContainsErrorsFunction(params CompilerError[] expectedErrors)
        {
            return new Action<IEnumerable<CompilerError>>((errors) =>
            {
                Assert.Equal(expectedErrors.Length, errors.Count());

                foreach (CompilerError expectedError in expectedErrors)
                {
                    Assert.Contains(expectedError, errors);
                }
            });
        }

        private static Action<IEnumerable<CompilerError>> CreateContainsErrorMessagesFunction(params string[] expectedErrorMessages)
        {
            return new Action<IEnumerable<CompilerError>>((errors) =>
            {
                IList<string> errorMessages = errors.Select(error => error.Description).ToList();

                Assert.Equal(expectedErrorMessages.Length, errorMessages.Count);

                foreach (string expectedErrorMessage in expectedErrorMessages)
                {
                    Assert.Contains(expectedErrorMessage, errorMessages, StringComparer.InvariantCultureIgnoreCase);
                }
            });
        }
    }
}
