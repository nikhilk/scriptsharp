// SwitchNode.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Diagnostics;

namespace ScriptSharp.CodeModel {

    internal sealed class SwitchNode : StatementNode {

        private ParseNode _condition;
        private ParseNodeList _cases;

        public SwitchNode(Token token,
                          ParseNode condition,
                          ParseNodeList cases)
            : base(ParseNodeType.Switch, token) {
            _condition = GetParentedNode(condition);
            _cases = GetParentedNodeList(cases);
        }

        public ParseNodeList Cases {
            get {
                return _cases;
            }
        }

        public ParseNode Condition {
            get {
                return _condition;
            }
        }
    }
}
