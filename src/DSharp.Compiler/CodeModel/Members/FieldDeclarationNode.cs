// FieldDeclarationNode.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System.Diagnostics;
using DSharp.Compiler.CodeModel.Attributes;
using DSharp.Compiler.CodeModel.Expressions;
using DSharp.Compiler.CodeModel.Tokens;

namespace DSharp.Compiler.CodeModel.Members
{
    internal class FieldDeclarationNode : MemberNode
    {
        public FieldDeclarationNode(Token token,
                                    ParseNodeList attributes,
                                    Modifiers modifiers,
                                    ParseNode type,
                                    ParseNodeList initializers,
                                    bool isFixed)
            : this(ParseNodeType.FieldDeclaration, token, attributes, modifiers, type, initializers, isFixed)
        {
        }

        protected FieldDeclarationNode(ParseNodeType nodeType, Token token,
                                       ParseNodeList attributes,
                                       Modifiers modifiers,
                                       ParseNode type,
                                       ParseNodeList initializers,
                                       bool isFixed)
            : base(nodeType, token)
        {
            Attributes = GetParentedNodeList(AttributeNode.GetAttributeList(attributes));
            Modifiers = modifiers;
            Type = GetParentedNode(type);
            Initializers = GetParentedNodeList(initializers);
            IsFixed = isFixed;
        }

        public override ParseNodeList Attributes { get; }

        public ParseNodeList Initializers { get; }

        public bool IsFixed { get; }

        public override Modifiers Modifiers { get; }

        public override string Name
        {
            get
            {
                Debug.Assert(Initializers.Count == 1);
                Debug.Assert(Initializers[0] is VariableInitializerNode);

                VariableInitializerNode variableNode = (VariableInitializerNode) Initializers[0];

                return variableNode.Name.Name;
            }
        }

        public override ParseNode Type { get; }
    }
}