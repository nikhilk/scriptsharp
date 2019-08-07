// NamespaceNode.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using DSharp.Compiler.CodeModel.Names;
using DSharp.Compiler.CodeModel.Tokens;

namespace DSharp.Compiler.CodeModel.Types
{
    internal sealed class NamespaceNode : ParseNode
    {
        private ParseNodeList externAliases;

        public NamespaceNode(Token token, NameNode nameNode,
                             ParseNodeList externAliases,
                             ParseNodeList usingClauses,
                             ParseNodeList members)
            : base(ParseNodeType.Namespace, token)
        {
            Name = nameNode.Name;
            this.externAliases = GetParentedNodeList(externAliases);
            UsingClauses = GetParentedNodeList(usingClauses);
            Members = GetParentedNodeList(members);
        }

        public NamespaceNode(Token token, string name,
                             ParseNodeList usingClauses,
                             ParseNodeList members)
            : base(ParseNodeType.Namespace, token)
        {
            Name = name;
            UsingClauses = GetParentedNodeList(usingClauses);
            Members = GetParentedNodeList(members);
        }

        public ParseNodeList Members { get; }

        public string Name { get; }

        public ParseNodeList UsingClauses { get; private set; }

        internal void IncludeCompilationUnitUsingClauses()
        {
            CompilationUnitNode compilationUnit = (CompilationUnitNode) Parent;

            if (compilationUnit.UsingClauses.Count != 0)
            {
                ParseNodeList mergedUsings = new ParseNodeList();
                mergedUsings.Append(compilationUnit.UsingClauses);

                if (UsingClauses.Count != 0)
                {
                    mergedUsings.Append(UsingClauses);
                }

                UsingClauses = GetParentedNodeList(mergedUsings);
            }
        }
    }
}