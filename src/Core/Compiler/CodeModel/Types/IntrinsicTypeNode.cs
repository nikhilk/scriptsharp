// IntrinsicTypeNode.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Diagnostics;

namespace ScriptSharp.CodeModel {

    internal sealed class IntrinsicTypeNode : TypeNode {

        private bool _nullable;

        public IntrinsicTypeNode(Token token)
            : base(ParseNodeType.PredefinedType, token) {
        }

        public TokenType Type {
            get {
                return token.Type;
            }
        }

        public bool IsNullable {
            get {
                return _nullable;
            }
        }

        public void AddNullability() {
            _nullable = true;
        }
    }
}
