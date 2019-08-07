// EventDeclarationNode.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System.Diagnostics;
using DSharp.Compiler.CodeModel.Attributes;
using DSharp.Compiler.CodeModel.Expressions;
using DSharp.Compiler.CodeModel.Statements;
using DSharp.Compiler.CodeModel.Tokens;

namespace DSharp.Compiler.CodeModel.Members
{
    internal sealed class EventDeclarationNode : MemberNode
    {
        private readonly ParseNode implementationMember;

        public EventDeclarationNode(Token token, ParseNodeList attributes, ParseNode backingMember)
            : base(ParseNodeType.EventDeclaration, token)
        {
            Attributes = GetParentedNodeList(AttributeNode.GetAttributeList(attributes));
            implementationMember = GetParentedNode(backingMember);
        }

        public override ParseNodeList Attributes { get; }

        public bool IsField => implementationMember is VariableDeclarationNode;

        public FieldDeclarationNode Field
        {
            get
            {
                if (implementationMember is VariableDeclarationNode variableNode)
                {
                    return new FieldDeclarationNode(variableNode.Token, new ParseNodeList(), variableNode.Modifiers,
                        variableNode.Type, variableNode.Initializers, false);
                }

                return null;
            }
        }

        public override Modifiers Modifiers
        {
            get
            {
                if (implementationMember is VariableDeclarationNode variableNode)
                {
                    return variableNode.Modifiers;
                }

                Debug.Assert(implementationMember is PropertyDeclarationNode);

                return ((PropertyDeclarationNode) implementationMember).Modifiers;
            }
        }

        public override string Name
        {
            get
            {
                if (implementationMember is VariableDeclarationNode variableNode)
                {
                    Debug.Assert(variableNode.Initializers.Count == 1);
                    Debug.Assert(variableNode.Initializers[0] is VariableInitializerNode);
                    VariableInitializerNode initializerNode = (VariableInitializerNode) variableNode.Initializers[0];

                    return initializerNode.Name.Name;
                }

                Debug.Assert(implementationMember is PropertyDeclarationNode);

                return ((PropertyDeclarationNode) implementationMember).Name;
            }
        }

        public PropertyDeclarationNode Property => implementationMember as PropertyDeclarationNode;

        public override ParseNode Type
        {
            get
            {
                if (implementationMember is VariableDeclarationNode variableNode)
                {
                    return variableNode.Type;
                }

                Debug.Assert(implementationMember is PropertyDeclarationNode);

                return ((PropertyDeclarationNode) implementationMember).Type;
            }
        }
    }
}