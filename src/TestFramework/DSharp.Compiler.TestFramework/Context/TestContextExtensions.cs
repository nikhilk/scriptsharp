namespace DSharp.Compiler.TestFramework.Context
{
    public static class TestContextExtensions
    {
        public static string GetExpectedOutput(this ITestContext testContext)
        {
            return testContext?.ExpectedOutput.OpenText()?.ReadToEnd();
        }
    }
}