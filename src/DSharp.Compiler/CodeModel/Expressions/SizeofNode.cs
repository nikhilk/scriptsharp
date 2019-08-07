// ExpressionNode.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using DSharp.Compiler.CodeModel.Tokens;

namespace DSharp.Compiler.CodeModel.Expressions
{
    // NOTE: Not supported in conversion
    internal class SizeofNode : ExpressionNode
    {
        private ParseNode typeNode;

        public SizeofNode(Token op, ParseNode typeNode)
            : base(ParseNodeType.Sizeof, op)
        {
            this.typeNode = GetParentedNode(typeNode);
        }
    }
}