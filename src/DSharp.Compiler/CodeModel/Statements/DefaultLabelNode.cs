// DefaultLabelNode.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using DSharp.Compiler.CodeModel.Tokens;

namespace DSharp.Compiler.CodeModel.Statements
{
    internal sealed class DefaultLabelNode : StatementNode
    {
        public DefaultLabelNode(Token token)
            : base(ParseNodeType.DefaultLabel, token)
        {
        }
    }
}