// ParameterNode.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using DSharp.Compiler.CodeModel.Attributes;
using DSharp.Compiler.CodeModel.Names;
using DSharp.Compiler.CodeModel.Tokens;

namespace DSharp.Compiler.CodeModel.Members
{
    internal sealed class ParameterNode : ParseNode
    {
        private readonly AtomicNameNode name;

        public ParameterNode(
            Token token, 
            ParseNodeList attributes, 
            ParameterFlags flags, 
            ParseNode type, 
            AtomicNameNode name, 
            bool isExtensionMethodTarget = false)
            : base(ParseNodeType.FormalParameter, token)
        {
            Attributes = GetParentedNodeList(AttributeNode.GetAttributeList(attributes));
            Flags = flags;
            IsExtensionMethodTarget = isExtensionMethodTarget;
            Type = GetParentedNode(type);
            this.name = (AtomicNameNode)GetParentedNode(name);
        }

        public ParseNodeList Attributes { get; }

        public ParameterFlags Flags { get; }

        public string Name => name.Name;

        public ParseNode Type { get; }

        public bool IsExtensionMethodTarget { get; }
    }
}
