// PreprocessorDeclarationLine.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

namespace DSharp.Compiler.Parser
{
    // #define/#undef
    internal sealed class PreprocessorDeclarationLine : PreprocessorLine
    {
        public PreprocessorDeclarationLine(PreprocessorTokenType type, Name identifier)
            : base(type)
        {
            Identifier = identifier;
        }

        public Name Identifier { get; }
    }
}