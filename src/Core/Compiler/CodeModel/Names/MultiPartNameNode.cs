// MultiPartNameNode.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Collections;
using System.Diagnostics;

namespace ScriptSharp.CodeModel {

    internal sealed class MultiPartNameNode : NameNode {

        private ParseNodeList _names;

        public MultiPartNameNode(Token token, ParseNodeList names)
            : base(ParseNodeType.MultiPartName, token) {
            _names = GetParentedNodeList(names);
        }

        protected sealed override ParseNodeList List {
            get {
                return _names;
            }
        }
    }
}
