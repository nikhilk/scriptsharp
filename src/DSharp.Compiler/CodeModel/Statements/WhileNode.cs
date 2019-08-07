// WhileNode.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using DSharp.Compiler.CodeModel.Tokens;

namespace DSharp.Compiler.CodeModel.Statements
{
    internal sealed class WhileNode : StatementNode
    {
        public WhileNode(Token token,
                         ParseNode condition,
                         ParseNode body)
            : base(ParseNodeType.While, token)
        {
            Condition = GetParentedNode(condition);
            Body = GetParentedNode(body);
        }

        public ParseNode Body { get; }

        public ParseNode Condition { get; }
    }
}