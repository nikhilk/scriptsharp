// EnumerationFieldNode.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using DSharp.Compiler.CodeModel.Attributes;
using DSharp.Compiler.CodeModel.Expressions;
using DSharp.Compiler.CodeModel.Names;
using DSharp.Compiler.CodeModel.Tokens;

namespace DSharp.Compiler.CodeModel.Members
{
    internal class EnumerationFieldNode : MemberNode
    {
        private readonly AtomicNameNode name;

        public EnumerationFieldNode(ParseNodeList attributes, AtomicNameNode name,
                                    ParseNode value)
            : base(ParseNodeType.EnumerationFieldDeclaration, name.Token)
        {
            Attributes = GetParentedNodeList(AttributeNode.GetAttributeList(attributes));
            this.name = (AtomicNameNode) GetParentedNode(name);

            if (value is LiteralNode)
            {
                LiteralNode literalNode = (LiteralNode) value;
                Value = ((LiteralToken) literalNode.Token).LiteralValue;
            }
            else
            {
                // TODO: Clearly we need something more general...
                //       C# allows expressions. Likely expressions to be used
                //       include negative values, binary OR'd values,
                //       expressions involving other enum members (esp. hard to deal with)
                // For now, just adding support for negative numbers, as
                // everything else can be worked around in source code.

                if (value is UnaryExpressionNode expressionNode && expressionNode.Operator == TokenType.Minus &&
                    expressionNode.Child is LiteralNode node)
                {
                    try
                    {
                        LiteralToken literalToken =
                            (LiteralToken) node.Token;
                        int numericValue = (int) Convert.ChangeType(literalToken.LiteralValue, typeof(int));

                        Value = -numericValue;
                    }
                    catch
                    {
                    }
                }
            }
        }

        public override ParseNodeList Attributes { get; }

        public override Modifiers Modifiers => Modifiers.Public;

        public override string Name => name.Name;

        public override ParseNode Type => null;

        public object Value { get; }
    }
}