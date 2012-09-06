// MemberNode.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Diagnostics;

namespace ScriptSharp.CodeModel {

    internal abstract class MemberNode : ParseNode {

        protected MemberNode(ParseNodeType nodeType, Token token)
            : base(nodeType, token) {
        }

        public abstract ParseNodeList Attributes {
            get;
        }

        public abstract Modifiers Modifiers {
            get;
        }

        public abstract string Name {
            get;
        }

        public abstract ParseNode Type {
            get;
        }
    }
}
