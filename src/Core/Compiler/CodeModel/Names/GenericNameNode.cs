// GenericNameNode.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Collections;
using System.Diagnostics;

namespace ScriptSharp.CodeModel {

    internal sealed class GenericNameNode : AtomicNameNode {

        private ParseNodeList _typeArguments;

        public GenericNameNode(IdentifierToken name, ParseNodeList typeArguments)
            : base(ParseNodeType.GenericName, name) {
            _typeArguments = typeArguments;
        }

        public ParseNodeList TypeArguments {
            get {
                return _typeArguments;
            }
        }
    }
}
