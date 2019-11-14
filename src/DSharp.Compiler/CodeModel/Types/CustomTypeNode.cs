// CustomTypeNode.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using DSharp.Compiler.CodeModel.Names;
using DSharp.Compiler.CodeModel.Tokens;

namespace DSharp.Compiler.CodeModel.Types
{
    internal sealed class CustomTypeNode : UserTypeNode
    {
        public CustomTypeNode(Token token, TokenType type,
                              ParseNodeList attributes,
                              Modifiers modifiers,
                              AtomicNameNode name,
                              ParseNodeList typeParameters,
                              ParseNodeList baseTypes,
                              ParseNodeList constraintClauses,
                              ParseNodeList members,
                              bool isNestedType)
            : base(ParseNodeType.Type, token, type, attributes, modifiers, name, typeParameters, constraintClauses, isNestedType)
        {
            BaseTypes = GetParentedNodeList(baseTypes);
            Members = GetParentedNodeList(members);
        }

        public ParseNodeList BaseTypes { get; }

        public ParseNodeList Members { get; }

        internal override void MergePartialType(CustomTypeNode partialTypeNode)
        {
            base.MergePartialType(partialTypeNode);

            if (partialTypeNode.BaseTypes.Count > 0)
            {
                BaseTypes.Append(GetParentedNodeList(partialTypeNode.BaseTypes));
            }
        }
    }
}
