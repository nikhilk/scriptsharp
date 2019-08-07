// IndexerDeclarationNode.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using DSharp.Compiler.CodeModel.Names;
using DSharp.Compiler.CodeModel.Tokens;

namespace DSharp.Compiler.CodeModel.Members
{
    internal sealed class IndexerDeclarationNode : PropertyDeclarationNode
    {
        public IndexerDeclarationNode(Token token,
                                      ParseNodeList attributes,
                                      Modifiers modifiers,
                                      ParseNode type,
                                      NameNode interfaceType,
                                      ParseNodeList parameters,
                                      AccessorNode get,
                                      AccessorNode set)
            : base(ParseNodeType.IndexerDeclaration, token, attributes, modifiers, type, interfaceType, get, set)
        {
            Parameters = GetParentedNodeList(parameters);
        }

        public override string Name => "Item";

        public ParseNodeList Parameters { get; }
    }
}