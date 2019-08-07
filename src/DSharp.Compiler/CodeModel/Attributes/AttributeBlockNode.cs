// AttributeBlockNode.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using DSharp.Compiler.CodeModel.Tokens;

namespace DSharp.Compiler.CodeModel.Attributes
{
    internal sealed class AttributeBlockNode : ParseNode
    {
        public AttributeBlockNode(Token token,
                                  ParseNodeList attributes)
            : base(ParseNodeType.AttributeBlock, token)
        {
            Attributes = GetParentedNodeList(attributes);
        }

        public ParseNodeList Attributes { get; }
    }
}