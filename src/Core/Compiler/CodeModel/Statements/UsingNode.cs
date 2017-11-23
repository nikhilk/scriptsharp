// UsingNode.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Diagnostics;

namespace ScriptSharp.CodeModel {

    // NOTE: Not supported in conversion
    internal sealed class UsingNode : StatementNode {

        private ParseNode _guard;
        private ParseNode _body;

        public UsingNode(Token token,
                         ParseNode guard,
                         ParseNode body)
            : base(ParseNodeType.Using, token) {
            _guard = GetParentedNode(guard);
            _body = GetParentedNode(body);
        }

        public ParseNode Body
        {
            get
            {
                return _body;
            }
        }

        public ParseNode Guard
        {
            get
            {
                return _guard;
            }
        }
    }
}
