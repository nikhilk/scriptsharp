// ExpressionListNode.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Diagnostics;

namespace ScriptSharp.CodeModel {

    internal sealed class ExpressionListNode : ParseNode {

        private ParseNodeList _expressions;

        public ExpressionListNode(Token token, ParseNodeList expressions)
            : base(ParseNodeType.ExpressionList, token) {
            _expressions = GetParentedNodeList(expressions);
        }

        public ParseNodeList Expressions {
            get {
                return _expressions;
            }
        }
    }
}
