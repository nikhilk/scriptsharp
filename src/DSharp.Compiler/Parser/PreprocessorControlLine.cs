// PreprocessorControlLine.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

namespace DSharp.Compiler.Parser
{
    // #error/#warning
    internal sealed class PreprocessorControlLine : PreprocessorLine
    {
        public PreprocessorControlLine(PreprocessorTokenType type, string message)
            : base(type)
        {
            Message = message.Trim();
        }

        public string Message { get; }
    }
}