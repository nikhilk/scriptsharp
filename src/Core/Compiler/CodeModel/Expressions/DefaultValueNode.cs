// ExpressionNode.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Diagnostics;

namespace ScriptSharp.CodeModel {

    // NOTE: Not supported in conversion
    internal sealed class DefaultValueNode : ExpressionNode {

        public ParseNode _expression;

        public DefaultValueNode(ParseNode expression)
            : base(ParseNodeType.DefaultValueExpression, expression.token) {
            _expression = expression;
        }
    }
}
