// TryNode.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Diagnostics;

namespace ScriptSharp.CodeModel {

    internal sealed class TryNode : StatementNode {

        private ParseNode _body;
        private ParseNodeList _catchClauses;
        private ParseNode _finallyClause;

        public TryNode(Token token,
                       ParseNode body,
                       ParseNodeList catchClauses,
                       ParseNode finallyClause)
            : base(ParseNodeType.Try, token) {
            _body = GetParentedNode(body);
            _catchClauses = GetParentedNodeList(catchClauses);
            _finallyClause = GetParentedNode(finallyClause);
        }

        public ParseNode Body {
            get {
                return _body;
            }
        }

        public ParseNodeList CatchClauses {
            get {
                return _catchClauses;
            }
        }

        public ParseNode FinallyClause {
            get {
                return _finallyClause;
            }
        }
    }
}
