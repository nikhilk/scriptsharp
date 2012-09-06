// AliasQualifiedNameNode.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Collections;
using System.Diagnostics;
using System.Text;

namespace ScriptSharp.CodeModel {

    internal sealed class AliasQualifiedNameNode : NameNode {

        private AtomicNameNode _aliasName;
        private NameNode _name;

        public AliasQualifiedNameNode(AtomicNameNode left, NameNode right)
            : base(ParseNodeType.AliasQualifiedName, left.token) {
            _aliasName = (AtomicNameNode)GetParentedNode(left);
            _name = (NameNode)GetParentedNode(right);
        }

        protected sealed override ParseNodeList List {
            get {
                return new ParseNodeList(this);
            }
        }
    }
}
