// UserTypeNode.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System.Diagnostics;
using DSharp.Compiler.CodeModel.Attributes;
using DSharp.Compiler.CodeModel.Names;
using DSharp.Compiler.CodeModel.Tokens;

namespace DSharp.Compiler.CodeModel.Types
{
    internal abstract class UserTypeNode : TypeNode
    {
        private readonly ParseNodeList constraintClauses;
        private readonly AtomicNameNode nameNode;

        public UserTypeNode(ParseNodeType type, Token token, TokenType tokenType,
                            ParseNodeList attributes,
                            Modifiers modifiers,
                            AtomicNameNode name,
                            ParseNodeList typeParameters,
                            ParseNodeList constraintClauses,
                            bool isNestedType = false)
            : base(type, token)
        {
            Type = tokenType;
            Attributes = GetParentedNodeList(AttributeNode.GetAttributeList(attributes));
            Modifiers = modifiers;
            nameNode = name;
            this.TypeParameters = GetParentedNodeList(typeParameters);
            this.constraintClauses = GetParentedNodeList(constraintClauses);
            IsNestedType = isNestedType;
        }

        public ParseNodeList TypeParameters { get; }

        public ParseNodeList Attributes { get; }

        public string Name => nameNode.Name;

        public NameNode NameNode => nameNode;

        public Modifiers Modifiers { get; private set; }

        public TokenType Type { get; }

        public bool IsNestedType { get; internal set; }

        internal virtual void MergePartialType(CustomTypeNode partialTypeNode)
        {
            Debug.Assert(Name == partialTypeNode.Name);

            if (partialTypeNode.Attributes.Count > 0)
            {
                Attributes.Append(GetParentedNodeList(partialTypeNode.Attributes));
            }

            if ((partialTypeNode.Modifiers & Modifiers.PartialModifiers) != 0)
            {
                Modifiers |= partialTypeNode.Modifiers & Modifiers.PartialModifiers;
            }

            if (partialTypeNode.TypeParameters.Count > 0)
            {
                TypeParameters.Append(GetParentedNodeList(partialTypeNode.TypeParameters));
            }

            if (partialTypeNode.constraintClauses.Count > 0)
            {
                constraintClauses.Append(GetParentedNodeList(partialTypeNode.constraintClauses));
            }
        }
    }
}
