// VariableInitializerNode.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Diagnostics;

namespace ScriptSharp.CodeModel {

    internal sealed class VariableInitializerNode : ExpressionNode {

        private AtomicNameNode _name;
        private ParseNode _value;

        public VariableInitializerNode(AtomicNameNode name, ParseNode value)
            : base(ParseNodeType.VariableDeclarator, name.token) {
            _name = (AtomicNameNode)GetParentedNode(name);
            _value = GetParentedNode(value);
        }

        public AtomicNameNode Name {
            get {
                return _name;
            }
        }

        public ParseNode Value {
            get {
                return _value;
            }
        }
    }
}
