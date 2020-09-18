using System.IO;

namespace DSharp.Compiler.TestFramework.Context
{
    public interface ITestContext
    {
        FileInfo[] SourceFiles { get; }

        FileInfo[] References { get; }

        FileInfo[] Resources { get; }

        string[] Defines { get; }

        FileInfo ExpectedOutput { get; }

        FileInfo CommentFile { get; }

        IStreamSourceResolver StreamSourceResolver { get; }

        TestContextCompliationOptions CompilationOptions { get; }

        FileInfo ExpectedMetadataOutput { get; }
    }
}
