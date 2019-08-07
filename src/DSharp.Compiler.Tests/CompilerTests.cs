using DSharp.Compiler.TestFramework.Compilation;
using DSharp.Compiler.TestFramework.Context;
using DSharp.Compiler.TestFramework.Data;
using DSharp.Compiler.Tests.Fixtures;
using Xunit;

namespace ss.Compiler.Tests
{
    public class CompilerTests : IClassFixture<TestContextFixture>
    {
        private readonly TestContextFixture compilerCompliationFixture;

        private ICompilationUnitFactory CompilationUnitFactory => compilerCompliationFixture?.CompilationUnitFactory;

        private ITestContextFactory TestContextFactory => compilerCompliationFixture?.TestContextFactory;

        public CompilerTests(TestContextFixture compilerCompliationFixture)
        {
            this.compilerCompliationFixture = compilerCompliationFixture;
        }

        [Theory]
        [JsonCategoryTestData(@"Source\CompilerTests.json")]
        public void TestCompilerOutput(string category, string testName)
        {
            ITestContext testContext = TestContextFactory.GetContext(category, testName);
            ICompilationUnit compilationUnit = CompilationUnitFactory.CreateCompilationUnitBuilder()
                .WithTestContext(testContext)
                .Build();

            Assert.True(compilationUnit.Compile(out ICompilationUnitResult result), result?.WriteErrors());

            string expectedOutput = testContext.GetExpectedOutput();
            Assert.Equal(expectedOutput, result.Output, compilerCompliationFixture.FileComparer);
        }
    }
}
