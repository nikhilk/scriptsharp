// UsingAliasNode.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Collections;
using System.Diagnostics;

namespace ScriptSharp.CodeModel {

    internal class UsingAliasNode : ParseNode {

        private AtomicNameNode _aliasName;
        private NameNode _typeName;

        public UsingAliasNode(Token token, AtomicNameNode name, NameNode type)
            : base(ParseNodeType.UsingAlias, token) {
            _aliasName = (AtomicNameNode)GetParentedNode(name);
            _typeName = (NameNode)GetParentedNode(type);
        }

        public string Alias {
            get {
                return _aliasName.Name;
            }
        }

        public string TypeName {
            get {
                return _typeName.Name;
            }
        }
    }
}
