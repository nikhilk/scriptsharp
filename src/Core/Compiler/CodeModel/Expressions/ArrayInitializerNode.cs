// ArrayInitializerNode.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Diagnostics;

namespace ScriptSharp.CodeModel {

    internal sealed class ArrayInitializerNode : ExpressionNode {

        private ParseNodeList _values;

        public ArrayInitializerNode(Token token,
                                    ParseNodeList values)
            : base(ParseNodeType.ArrayInitializer, token) {
            _values = GetParentedNodeList(values);
        }

        public ParseNodeList Values {
            get {
                return _values;
            }
        }
    }
}
