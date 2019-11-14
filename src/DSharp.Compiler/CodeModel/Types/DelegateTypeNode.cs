// DelegateTypeNode.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using DSharp.Compiler.CodeModel.Names;
using DSharp.Compiler.CodeModel.Tokens;

namespace DSharp.Compiler.CodeModel.Types
{
    // NOTE: Ignored in conversion
    internal sealed class DelegateTypeNode : UserTypeNode
    {
        public DelegateTypeNode(Token token,
                                ParseNodeList attributes,
                                Modifiers modifiers,
                                ParseNode returnType,
                                AtomicNameNode name,
                                ParseNodeList typeParameters,
                                ParseNodeList parameters,
                                ParseNodeList constraintClauses,
                                bool isNestedType)
            : base(ParseNodeType.Delegate, token, TokenType.Delegate, attributes, modifiers, name, typeParameters,
                constraintClauses, isNestedType)
        {
            ReturnType = GetParentedNode(returnType);
            Parameters = GetParentedNodeList(parameters);
        }

        public ParseNodeList Parameters { get; }

        public ParseNode ReturnType { get; }
    }
}
