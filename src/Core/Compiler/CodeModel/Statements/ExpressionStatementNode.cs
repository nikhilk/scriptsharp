// ExpressionStatementNode.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Diagnostics;

namespace ScriptSharp.CodeModel {

    internal class ExpressionStatementNode : StatementNode {

        private ParseNode _expression;

        public ExpressionStatementNode(ParseNode expression)
            : base(ParseNodeType.ExpressionStatement, expression.token) {
            _expression = GetParentedNode(expression);
        }

        public ParseNode Expression {
            get {
                return _expression;
            }
        }
    }
}
