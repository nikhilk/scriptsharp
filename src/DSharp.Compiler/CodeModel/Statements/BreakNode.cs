// BreakNode.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using DSharp.Compiler.CodeModel.Tokens;

namespace DSharp.Compiler.CodeModel.Statements
{
    internal sealed class BreakNode : StatementNode
    {
        public BreakNode(Token token)
            : base(ParseNodeType.Break, token)
        {
        }
    }
}