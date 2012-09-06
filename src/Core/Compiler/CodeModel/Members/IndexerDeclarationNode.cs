// IndexerDeclarationNode.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Diagnostics;

namespace ScriptSharp.CodeModel {

    internal sealed class IndexerDeclarationNode : PropertyDeclarationNode {

        private ParseNodeList _parameters;

        public IndexerDeclarationNode(Token token,
                                      ParseNodeList attributes,
                                      Modifiers modifiers,
                                      ParseNode type,
                                      NameNode interfaceType,
                                      ParseNodeList parameters,
                                      AccessorNode get,
                                      AccessorNode set)
            : base(ParseNodeType.IndexerDeclaration, token, attributes, modifiers, type, interfaceType, get, set) {

            _parameters = GetParentedNodeList(parameters);
        }

        public override string Name {
            get {
                return "Item";
            }
        }

        public ParseNodeList Parameters {
            get {
                return _parameters;
            }
        }
    }
}
