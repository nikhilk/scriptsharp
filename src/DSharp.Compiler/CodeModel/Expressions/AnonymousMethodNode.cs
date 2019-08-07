// AnonymousMethodNode.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using DSharp.Compiler.CodeModel.Statements;
using DSharp.Compiler.CodeModel.Tokens;

namespace DSharp.Compiler.CodeModel.Expressions
{
    // NOTE: Not supported in conversion
    internal sealed class AnonymousMethodNode : ExpressionNode
    {
        public AnonymousMethodNode(Token token, ParseNodeList parameterList, BlockStatementNode block)
            : base(ParseNodeType.AnonymousMethod, token)
        {
            Parameters = GetParentedNodeList(parameterList);
            Implementation = (BlockStatementNode) GetParentedNode(block);
        }

        public BlockStatementNode Implementation { get; }

        public ParseNodeList Parameters { get; }
    }
}