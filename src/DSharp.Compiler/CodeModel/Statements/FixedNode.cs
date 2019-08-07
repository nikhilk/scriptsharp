// FixedNode.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using DSharp.Compiler.CodeModel.Tokens;

namespace DSharp.Compiler.CodeModel.Statements
{
    // NOTE: Not supported in conversion
    internal sealed class FixedNode : StatementNode
    {
        private ParseNode body;

        private VariableDeclarationNode declaration;

        public FixedNode(Token token,
                         VariableDeclarationNode declaration,
                         ParseNode body)
            : base(ParseNodeType.Fixed, token)
        {
            this.declaration = (VariableDeclarationNode) GetParentedNode(declaration);
            this.body = GetParentedNode(body);
        }
    }
}