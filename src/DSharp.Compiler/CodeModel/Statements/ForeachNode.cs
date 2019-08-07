// ForeachNode.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using DSharp.Compiler.CodeModel.Names;
using DSharp.Compiler.CodeModel.Tokens;

namespace DSharp.Compiler.CodeModel.Statements
{
    // NOTE: Not supported in conversion
    internal class ForeachNode : StatementNode
    {
        public ForeachNode(Token token,
                           ParseNode type,
                           AtomicNameNode name,
                           ParseNode container,
                           ParseNode body)
            : base(ParseNodeType.Foreach, token)
        {
            Type = GetParentedNode(type);
            Name = (AtomicNameNode) GetParentedNode(name);
            Container = GetParentedNode(container);
            Body = GetParentedNode(body);
        }

        public ParseNode Body { get; }

        public ParseNode Container { get; }

        public ParseNode Type { get; }

        public AtomicNameNode Name { get; }
    }
}