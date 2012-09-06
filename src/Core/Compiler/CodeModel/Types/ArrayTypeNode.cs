// ArrayTypeNode.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Diagnostics;

namespace ScriptSharp.CodeModel {

    internal sealed class ArrayTypeNode : TypeNode {

        private ParseNode _baseType;
        private int _rank;

        public ArrayTypeNode(ParseNode baseType, int rank)
            : base(ParseNodeType.ArrayType, baseType.token) {
            _baseType = GetParentedNode(baseType);
            _rank = rank;
        }

        public ParseNode BaseType {
            get {
                return _baseType;
            }
        }

        public int Rank {
            get {
                return _rank;
            }
        }
    }
}
