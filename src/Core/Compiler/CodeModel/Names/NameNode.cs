// NameNode.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Collections;
using System.Diagnostics;
using System.Text;

namespace ScriptSharp.CodeModel {

    internal abstract class NameNode : ParseNode {

        private string _name;

        protected NameNode(ParseNodeType nodeType, Token token)
            : base(nodeType, token) {
        }

        protected abstract ParseNodeList List {
            get;
        }

        public string Name {
            get {
                if (_name == null) {
                    StringBuilder sb = new StringBuilder();
                    foreach (AtomicNameNode symbolNode in List) {
                        if (sb.Length != 0) {
                            sb.Append('.');
                        }
                        sb.Append(symbolNode.Identifier);
                    }

                    _name = sb.ToString();
                }
                return _name;
            }
        }
    }
}
