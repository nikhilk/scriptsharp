// DoWhileNode.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using DSharp.Compiler.CodeModel.Tokens;

namespace DSharp.Compiler.CodeModel.Statements
{
    internal sealed class DoWhileNode : StatementNode
    {
        public DoWhileNode(Token token,
                           ParseNode body,
                           ParseNode condition)
            : base(ParseNodeType.DoWhile, token)
        {
            Body = GetParentedNode(body);
            Condition = GetParentedNode(condition);
        }

        public ParseNode Body { get; }

        public ParseNode Condition { get; }
    }
}