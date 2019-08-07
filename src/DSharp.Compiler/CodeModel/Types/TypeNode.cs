// TypeNode.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using DSharp.Compiler.CodeModel.Tokens;

namespace DSharp.Compiler.CodeModel.Types
{
    internal abstract class TypeNode : ParseNode
    {
        protected TypeNode(ParseNodeType nodeType, Token token)
            : base(nodeType, token)
        {
        }
    }
}