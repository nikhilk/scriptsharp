using System;

namespace DSharp.Compiler
{
    public sealed class ExpressionBuildException : Exception
    {
        public ExpressionBuildException(string message)
            : base(message)
        {
        }
    }
}
