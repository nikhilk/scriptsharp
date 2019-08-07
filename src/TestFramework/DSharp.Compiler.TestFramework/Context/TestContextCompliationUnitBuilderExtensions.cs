using System.Linq;
using DSharp.Compiler.TestFramework.Compilation;

namespace DSharp.Compiler.TestFramework.Context
{
    public static class TestContextCompliationUnitBuilderExtensions
    {
        public static ICompilationUnitBuilder WithTestContext(this ICompilationUnitBuilder compilationUnitBuilder, ITestContext testContext)
        {
            return compilationUnitBuilder
                .AddSourceFiles(testContext.SourceFiles.Select(file => file.FullName).ToArray())
                .AddDefines(testContext.Defines)
                .AddReferences(testContext.References.Select(file => file.FullName).ToArray())
                .AddResources(testContext.Resources?.Select(file => file.FullName)?.ToArray())
                .AddCommentFile(testContext.CommentFile?.FullName)
                .AddStreamResolver(testContext.StreamSourceResolver)
                .WithCompilationOptions(testContext.CompilationOptions);
        }
    }
}