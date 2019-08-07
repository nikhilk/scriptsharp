// CompilationUnitNode.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using DSharp.Compiler.CodeModel.Tokens;

namespace DSharp.Compiler.CodeModel.Types
{
    internal sealed class CompilationUnitNode : ParseNode
    {
        private ParseNodeList externAliases;

        public CompilationUnitNode(Token token,
                                   ParseNodeList externAliases,
                                   ParseNodeList usingClauses,
                                   ParseNodeList attributes,
                                   ParseNodeList members)
            : base(ParseNodeType.CompilationUnit, token)
        {
            this.externAliases = GetParentedNodeList(externAliases);
            UsingClauses = GetParentedNodeList(usingClauses);
            Attributes = GetParentedNodeList(attributes);
            Members = GetParentedNodeList(GetNamespaces(members));
        }

        public ParseNodeList Members { get; }

        public ParseNodeList UsingClauses { get; }

        public ParseNodeList Attributes { get; }

        private ParseNodeList GetNamespaces(ParseNodeList members)
        {
            ParseNodeList namespaceList = new ParseNodeList();

            foreach (ParseNode memberNode in members)
            {
                if (!(memberNode is NamespaceNode namespaceNode))
                {
                    // Top-level type nodes are turned into children of a namespace with
                    // an empty name.

                    Token nsToken = new Token(TokenType.Namespace, memberNode.Token.SourcePath,
                        memberNode.Token.Position);
                    namespaceNode =
                        new NamespaceNode(nsToken, string.Empty, UsingClauses, new ParseNodeList(memberNode));
                }

                namespaceList.Append(namespaceNode);
            }

            return namespaceList;
        }
    }
}