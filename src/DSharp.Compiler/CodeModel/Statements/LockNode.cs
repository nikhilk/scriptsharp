// LockNode.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using DSharp.Compiler.CodeModel.Tokens;

namespace DSharp.Compiler.CodeModel.Statements
{
    // NOTE: Not supported in conversion
    internal sealed class LockNode : StatementNode
    {
        public ParseNode Body;

        public ParseNode Monitor;

        public LockNode(Token token,
                        ParseNode monitor,
                        ParseNode body)
            : base(ParseNodeType.Lock, token)
        {
            Monitor = GetParentedNode(monitor);
            Body = GetParentedNode(body);
        }
    }
}