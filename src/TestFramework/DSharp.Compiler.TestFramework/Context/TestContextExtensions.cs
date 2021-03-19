namespace DSharp.Compiler.TestFramework.Context
{
    public static class TestContextExtensions
    {
        public static string GetExpectedOutput(this ITestContext testContext)
        {
            using (var reader = testContext?.ExpectedOutput?.OpenText()) {
                return reader?.ReadToEnd();
            }
        }

        public static string GetExpectedMetadata(this ITestContext testContext)
        {
            using (var reader = testContext?.ExpectedMetadataOutput?.OpenText())
            {
                return reader?.ReadToEnd();
            }
        }
    }
}
