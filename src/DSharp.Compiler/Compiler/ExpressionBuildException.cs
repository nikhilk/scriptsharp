using System;
using DSharp.Compiler.CodeModel;

namespace DSharp.Compiler
{
    internal sealed class ExpressionBuildException : Exception
    {
        public ExpressionBuildException(ParseNode node, string message)
            : base(message)
        {
            Node = node;
        }

        public ParseNode Node { get; }
    }
}
