// VariableInitializerNode.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using DSharp.Compiler.CodeModel.Names;

namespace DSharp.Compiler.CodeModel.Expressions
{
    internal sealed class VariableInitializerNode : ExpressionNode
    {
        public VariableInitializerNode(AtomicNameNode name, ParseNode value)
            : base(ParseNodeType.VariableDeclarator, name.Token)
        {
            Name = (AtomicNameNode) GetParentedNode(name);
            Value = GetParentedNode(value);
        }

        public AtomicNameNode Name { get; }

        public ParseNode Value { get; }
    }
}