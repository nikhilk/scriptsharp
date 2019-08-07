// ArrayInitializerNode.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using DSharp.Compiler.CodeModel.Tokens;

namespace DSharp.Compiler.CodeModel.Expressions
{
    internal sealed class ArrayInitializerNode : ExpressionNode
    {
        public ArrayInitializerNode(Token token,
                                    ParseNodeList values)
            : base(ParseNodeType.ArrayInitializer, token)
        {
            Values = GetParentedNodeList(values);
        }

        public ParseNodeList Values { get; }
    }
}