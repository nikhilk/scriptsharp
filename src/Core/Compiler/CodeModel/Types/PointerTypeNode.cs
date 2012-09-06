// PointerTypeNode.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Diagnostics;

namespace ScriptSharp.CodeModel {

    // NOTE: Not supported in conversion
    internal sealed class PointerTypeNode : TypeNode {

        private ParseNode _baseType;

        public PointerTypeNode(ParseNode baseType)
            : base(ParseNodeType.PointerType, baseType.token) {
            _baseType = GetParentedNode(baseType);
        }
    }
}
