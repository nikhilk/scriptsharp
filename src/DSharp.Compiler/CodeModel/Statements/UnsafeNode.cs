// UnsafeNode.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using DSharp.Compiler.CodeModel.Tokens;

namespace DSharp.Compiler.CodeModel.Statements
{
    // NOTE: Not supported in conversion
    internal class UnsafeNode : StatementNode
    {
        private ParseNode body;

        public UnsafeNode(Token token, ParseNode body)
            : base(ParseNodeType.UnsafeStatement, token)
        {
            this.body = body;
        }
    }
}