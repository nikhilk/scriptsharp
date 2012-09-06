// NamespaceNode.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Collections;
using System.Diagnostics;

namespace ScriptSharp.CodeModel {

    internal sealed class NamespaceNode : ParseNode {

        private string _name;
        private ParseNodeList _externAliases;
        private ParseNodeList _usingClauses;
        private ParseNodeList _members;

        public NamespaceNode(Token token, NameNode nameNode,
                             ParseNodeList externAliases,
                             ParseNodeList usingClauses,
                             ParseNodeList members)
            : base(ParseNodeType.Namespace, token) {
            _name = nameNode.Name;
            _externAliases = GetParentedNodeList(externAliases);
            _usingClauses = GetParentedNodeList(usingClauses);
            _members = GetParentedNodeList(members);
        }

        public NamespaceNode(Token token, string name,
                             ParseNodeList usingClauses,
                             ParseNodeList members)
            : base(ParseNodeType.Namespace, token) {
            _name = name;
            _usingClauses = GetParentedNodeList(usingClauses);
            _members = GetParentedNodeList(members);
        }

        public ParseNodeList Members {
            get {
                return _members;
            }
        }

        public string Name {
            get {
                return _name;
            }
        }

        public ParseNodeList UsingClauses {
            get {
                return _usingClauses;
            }
        }

        internal void IncludeCompilationUnitUsingClauses() {
            CompilationUnitNode compilationUnit = (CompilationUnitNode)parent;
            if (compilationUnit.UsingClauses.Count != 0) {
                ParseNodeList mergedUsings = new ParseNodeList();
                mergedUsings.Append(compilationUnit.UsingClauses);

                if (_usingClauses.Count != 0) {
                    mergedUsings.Append(_usingClauses);
                }

                _usingClauses = GetParentedNodeList(mergedUsings);
            }
        }
    }
}
