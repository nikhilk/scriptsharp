// CatchNode.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using DSharp.Compiler.CodeModel.Names;
using DSharp.Compiler.CodeModel.Tokens;

namespace DSharp.Compiler.CodeModel.Statements
{
    internal sealed class CatchNode : StatementNode
    {
        public CatchNode(Token token, ParseNode type,
                         AtomicNameNode name,
                         ParseNode body)
            : base(ParseNodeType.Catch, token)
        {
            Type = GetParentedNode(type);
            Name = (AtomicNameNode) GetParentedNode(name);
            Body = GetParentedNode(body);
        }

        public ParseNode Body { get; }

        public AtomicNameNode Name { get; }

        public ParseNode Type { get; }
    }
}