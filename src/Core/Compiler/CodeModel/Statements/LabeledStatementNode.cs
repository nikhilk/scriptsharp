// LabeledStatementNode.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Diagnostics;

namespace ScriptSharp.CodeModel {

    // NOTE: Not supported in conversion
    internal class LabeledStatementNode : StatementNode {

        private AtomicNameNode _label;
        private ParseNode _statement;

        public LabeledStatementNode(AtomicNameNode label, ParseNode statement)
            : base(ParseNodeType.LabeledStatement, label.token) {
            _label = (AtomicNameNode)GetParentedNode(label);
            _statement = GetParentedNode(statement);
        }
    }
}
