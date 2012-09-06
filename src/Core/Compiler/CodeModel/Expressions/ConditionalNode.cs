// ConditionalNode.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Diagnostics;

namespace ScriptSharp.CodeModel {

    internal sealed class ConditionalNode : ExpressionNode {

        private ParseNode _condition;
        private ParseNode _trueValue;
        private ParseNode _falseValue;

        public ConditionalNode(ParseNode condition, ParseNode trueValue, ParseNode falseValue)
            : base(ParseNodeType.Conditional, condition.token) {
            _condition = GetParentedNode(condition);
            _trueValue = GetParentedNode(trueValue);
            _falseValue = GetParentedNode(falseValue);
        }

        public ParseNode Condition {
            get {
                return _condition;
            }
        }

        public ParseNode FalseValue {
            get {
                return _falseValue;
            }
        }

        public ParseNode TrueValue {
            get {
                return _trueValue;
            }
        }
    }
}
