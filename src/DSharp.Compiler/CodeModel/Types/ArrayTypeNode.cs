// ArrayTypeNode.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

namespace DSharp.Compiler.CodeModel.Types
{
    internal sealed class ArrayTypeNode : TypeNode
    {
        public ArrayTypeNode(ParseNode baseType, int rank)
            : base(ParseNodeType.ArrayType, baseType.Token)
        {
            BaseType = GetParentedNode(baseType);
            Rank = rank;
        }

        public ParseNode BaseType { get; }

        public int Rank { get; }
    }
}