// PointerTypeNode.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

namespace DSharp.Compiler.CodeModel.Types
{
    // NOTE: Not supported in conversion
    internal sealed class PointerTypeNode : TypeNode
    {
        private ParseNode baseType;

        public PointerTypeNode(ParseNode baseType)
            : base(ParseNodeType.PointerType, baseType.Token)
        {
            this.baseType = GetParentedNode(baseType);
        }
    }
}