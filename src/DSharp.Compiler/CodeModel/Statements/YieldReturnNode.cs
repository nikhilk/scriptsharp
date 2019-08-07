// YieldReturnNode.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using DSharp.Compiler.CodeModel.Tokens;

namespace DSharp.Compiler.CodeModel.Statements
{
    // NOTE: Not supported in conversion
    internal sealed class YieldReturnNode : StatementNode
    {
        private ParseNode value;

        public YieldReturnNode(Token token, ParseNode value)
            : base(ParseNodeType.YieldReturn, token)
        {
            this.value = GetParentedNode(value);
        }
    }
}