// IntrinsicTypeNode.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using DSharp.Compiler.CodeModel.Tokens;

namespace DSharp.Compiler.CodeModel.Types
{
    internal sealed class IntrinsicTypeNode : TypeNode
    {
        public IntrinsicTypeNode(Token token)
            : base(ParseNodeType.PredefinedType, token)
        {
        }

        public TokenType Type => Token.Type;

        public bool IsNullable { get; private set; }

        public void AddNullability()
        {
            IsNullable = true;
        }
    }
}