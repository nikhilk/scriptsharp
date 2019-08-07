// IfElseNode.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using DSharp.Compiler.CodeModel.Tokens;

namespace DSharp.Compiler.CodeModel.Statements
{
    internal sealed class IfElseNode : StatementNode
    {
        public IfElseNode(Token token,
                          ParseNode condition,
                          ParseNode ifBlock,
                          ParseNode elseBlock)
            : base(ParseNodeType.IfElse, token)
        {
            Condition = GetParentedNode(condition);
            IfBlock = GetParentedNode(ifBlock);
            ElseBlock = GetParentedNode(elseBlock);
        }

        public ParseNode Condition { get; }

        public ParseNode ElseBlock { get; }

        public ParseNode IfBlock { get; }
    }
}