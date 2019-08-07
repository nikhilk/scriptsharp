// StackAllocNode.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using DSharp.Compiler.CodeModel.Tokens;

namespace DSharp.Compiler.CodeModel.Expressions
{
    // NOTE: Not supported in conversion
    internal sealed class StackAllocNode : ExpressionNode
    {
        private ParseNode numberOfElements;

        private ParseNode type;

        public StackAllocNode(Token token, ParseNode type, ParseNode numberOfElements)
            : base(ParseNodeType.StackAlloc, token)
        {
            this.type = GetParentedNode(type);
            this.numberOfElements = GetParentedNode(numberOfElements);
        }
    }
}