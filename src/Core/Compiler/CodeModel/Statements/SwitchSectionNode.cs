// SwitchSectionNode.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Diagnostics;

namespace ScriptSharp.CodeModel {

    internal sealed class SwitchSectionNode : StatementNode {

        private ParseNodeList _labels;
        private ParseNodeList _statements;

        public SwitchSectionNode(Token token,
                                 ParseNodeList labels,
                                 ParseNodeList statements)
            : base(ParseNodeType.SwitchSection, token) {
            _labels = GetParentedNodeList(labels);
            _statements = GetParentedNodeList(statements);
        }

        public ParseNodeList Labels {
            get {
                return _labels;
            }
        }

        public ParseNodeList Statements {
            get {
                return _statements;
            }
        }
    }
}
