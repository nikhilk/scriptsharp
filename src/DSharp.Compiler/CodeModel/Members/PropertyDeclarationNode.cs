// PropertyDeclarationNode.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System.Diagnostics;
using DSharp.Compiler.CodeModel.Attributes;
using DSharp.Compiler.CodeModel.Names;
using DSharp.Compiler.CodeModel.Tokens;

namespace DSharp.Compiler.CodeModel.Members
{
    internal class PropertyDeclarationNode : MemberNode
    {
        private readonly NameNode interfaceType;

        public PropertyDeclarationNode(Token token,
                                       ParseNodeList attributes,
                                       Modifiers modifiers,
                                       ParseNode type,
                                       NameNode interfaceType,
                                       AtomicNameNode name,
                                       AccessorNode getOrRemove,
                                       AccessorNode setOrAdd)
            : this(ParseNodeType.PropertyDeclaration, token, attributes, modifiers, type, interfaceType, getOrRemove,
                setOrAdd)
        {
            NameNode = (AtomicNameNode) GetParentedNode(name);
        }

        protected PropertyDeclarationNode(ParseNodeType nodeType, Token token,
                                          ParseNodeList attributes,
                                          Modifiers modifiers,
                                          ParseNode type,
                                          NameNode interfaceType,
                                          AccessorNode getOrRemove,
                                          AccessorNode setOrAdd)
            : base(nodeType, token)
        {
            Attributes = GetParentedNodeList(AttributeNode.GetAttributeList(attributes));
            Modifiers = modifiers;
            Type = GetParentedNode(type);
            this.interfaceType = (NameNode) GetParentedNode(interfaceType);
            GetAccessor = (AccessorNode) GetParentedNode(getOrRemove);
            SetAccessor = (AccessorNode) GetParentedNode(setOrAdd);
        }

        public override ParseNodeList Attributes { get; }

        public AccessorNode GetAccessor { get; }

        public ParseNode InterfaceType => interfaceType;

        public override Modifiers Modifiers { get; }

        public override string Name
        {
            get
            {
                Debug.Assert(NameNode != null);

                return NameNode.Name;
            }
        }

        public NameNode NameNode { get; }

        public AccessorNode SetAccessor { get; }

        public override ParseNode Type { get; }

        public bool IsAutoProperty 
            => (GetAccessor?.IsAutoProperty ?? false) 
            || (SetAccessor?.IsAutoProperty ?? false);

        public bool IsReadonlyProperty
            => GetAccessor != null
            && SetAccessor == null
            && GetAccessor.IsAutoProperty;
    }
}
