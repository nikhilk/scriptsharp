using System;
using DSharp.Compiler.ScriptModel.Symbols;

namespace DSharp.Compiler.Generator
{
    internal sealed class ScriptGeneratorException : Exception
    {
        public ScriptGeneratorException(Symbol symbol, string message)
            : base(message)
        {
            Symbol = symbol;
        }

        public Symbol Symbol { get; }
    }
}
