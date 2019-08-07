// UsingNode.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using DSharp.Compiler.CodeModel.Tokens;

namespace DSharp.Compiler.CodeModel.Statements
{
    // NOTE: Not supported in conversion
    internal sealed class UsingNode : StatementNode
    {
        public UsingNode(Token token,
                         ParseNode guard,
                         ParseNode body)
            : base(ParseNodeType.Using, token)
        {
            Guard = GetParentedNode(guard);
            Body = GetParentedNode(body);
        }

        public ParseNode Body { get; }

        public ParseNode Guard { get; }
    }
}