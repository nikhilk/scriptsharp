// YieldBreakNode.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using DSharp.Compiler.CodeModel.Tokens;

namespace DSharp.Compiler.CodeModel.Statements
{
    // NOTE: Not supported in conversion
    internal sealed class YieldBreakNode : StatementNode
    {
        public YieldBreakNode(Token token)
            : base(ParseNodeType.YieldBreak, token)
        {
        }
    }
}