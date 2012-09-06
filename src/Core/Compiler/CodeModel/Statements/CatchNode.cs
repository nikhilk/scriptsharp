// CatchNode.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Diagnostics;

namespace ScriptSharp.CodeModel {

    internal sealed class CatchNode : StatementNode {

        private ParseNode _type;
        private ParseNode _body;
        private AtomicNameNode _name;

        public CatchNode(Token token, ParseNode type,
                         AtomicNameNode name,
                         ParseNode body)
            : base(ParseNodeType.Catch, token) {
            _type = GetParentedNode(type);
            _name = (AtomicNameNode)GetParentedNode(name);
            _body = GetParentedNode(body);
        }

        public ParseNode Body {
            get {
                return _body;
            }
        }

        public AtomicNameNode Name {
            get {
                return _name;
            }
        }

        public ParseNode Type {
            get {
                return _type;
            }
        }
    }
}
