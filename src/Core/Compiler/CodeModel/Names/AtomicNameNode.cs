// AtomicNameNode.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Collections;
using System.Diagnostics;

namespace ScriptSharp.CodeModel {

    internal class AtomicNameNode : NameNode {

        private IdentifierToken _identifier;

        public AtomicNameNode(IdentifierToken identifier)
            : this(ParseNodeType.Name, identifier) {
        }

        protected AtomicNameNode(ParseNodeType nodeType, IdentifierToken identifier)
            : base(nodeType, identifier) {
            _identifier = identifier;
        }

        public IdentifierToken Identifier {
            get {
                return _identifier;
            }
        }

        protected sealed override ParseNodeList List {
            get {
                return new ParseNodeList(this);
            }
        }
    }
}
