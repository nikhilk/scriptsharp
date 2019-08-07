// VariableDeclarationNode.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using DSharp.Compiler.CodeModel.Tokens;

namespace DSharp.Compiler.CodeModel.Statements
{
    internal class VariableDeclarationNode : StatementNode
    {
        private ParseNodeList attributes;

        public VariableDeclarationNode(Token token,
                                       ParseNodeList attributes,
                                       Modifiers modifiers,
                                       ParseNode type,
                                       ParseNodeList initializers,
                                       bool isFixed)
            : this(ParseNodeType.VariableDeclaration, token, attributes, modifiers, type, initializers, isFixed)
        {
        }

        protected VariableDeclarationNode(ParseNodeType nodeType, Token token,
                                          ParseNodeList attributes,
                                          Modifiers modifiers,
                                          ParseNode type,
                                          ParseNodeList initializers,
                                          bool isFixed)
            : base(nodeType, token)
        {
            this.attributes = GetParentedNodeList(attributes);
            Modifiers = modifiers;
            Type = GetParentedNode(type);
            Initializers = GetParentedNodeList(initializers);
            IsFixed = isFixed;
        }

        public ParseNodeList Initializers { get; }

        public bool IsFixed { get; }

        public Modifiers Modifiers { get; }

        public ParseNode Type { get; }
    }
}