// ForeachNode.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Diagnostics;

namespace ScriptSharp.CodeModel {

    // NOTE: Not supported in conversion
    internal class ForeachNode : StatementNode {

        private ParseNode _type;
        private AtomicNameNode _name;
        private ParseNode _container;
        private ParseNode _body;

        public ForeachNode(Token token,
                           ParseNode type,
                           AtomicNameNode name,
                           ParseNode container,
                           ParseNode body)
            : base(ParseNodeType.Foreach, token) {
            _type = GetParentedNode(type);
            _name = (AtomicNameNode)GetParentedNode(name);
            _container = GetParentedNode(container);
            _body = GetParentedNode(body);
        }

        public ParseNode Body {
            get {
                return _body;
            }
        }

        public ParseNode Container {
            get {
                return _container;
            }
        }

        public ParseNode Type {
            get {
                return _type;
            }
        }

        public AtomicNameNode Name {
            get {
                return _name;
            }
        }
    }
}
