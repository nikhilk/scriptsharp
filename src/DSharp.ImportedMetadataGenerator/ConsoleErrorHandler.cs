using System;
using DSharp.Compiler.Errors;

namespace DSharp.ImportedMetadataGenerator
{
    internal class ConsoleErrorHandler : IErrorHandler
    {
        public void ReportError(CompilerError error)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Error: {error}");
        }

        public void ReportWarning(CompilerError error)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Warning: {error}");
        }
    }
}
