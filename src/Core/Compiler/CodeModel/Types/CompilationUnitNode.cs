// CompilationUnitNode.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Diagnostics;

namespace ScriptSharp.CodeModel {

    internal sealed class CompilationUnitNode : ParseNode {

        private ParseNodeList _externAliases;
        private ParseNodeList _usingClauses;
        private ParseNodeList _members;
        private ParseNodeList _attributes;

        public CompilationUnitNode(Token token,
                                   ParseNodeList externAliases,
                                   ParseNodeList usingClauses,
                                   ParseNodeList attributes,
                                   ParseNodeList members)
            : base(ParseNodeType.CompilationUnit, token) {
            _externAliases = GetParentedNodeList(externAliases);
            _usingClauses = GetParentedNodeList(usingClauses);
            _attributes = GetParentedNodeList(attributes);
            _members = GetParentedNodeList(GetNamespaces(members));
        }

        public ParseNodeList Members {
            get {
                return _members;
            }
        }

        public ParseNodeList UsingClauses {
            get {
                return _usingClauses;
            }
        }

        public ParseNodeList Attributes {
            get {
                return _attributes;
            }
        }

        private ParseNodeList GetNamespaces(ParseNodeList members) {
            ParseNodeList namespaceList = new ParseNodeList();

            foreach (ParseNode memberNode in members) {
                NamespaceNode namespaceNode = memberNode as NamespaceNode;

                if (namespaceNode == null) {
                    // Top-level type nodes are turned into children of a namespace with
                    // an empty name.

                    Token nsToken = new Token(TokenType.Namespace, memberNode.Token.SourcePath, memberNode.Token.Position);
                    namespaceNode = new NamespaceNode(nsToken, String.Empty, _usingClauses, new ParseNodeList(memberNode));
                }

                namespaceList.Append(namespaceNode);
            }

            return namespaceList;
        }
    }
}
